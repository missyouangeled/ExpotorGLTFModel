﻿using System;
using System.IO;
using System.IO.Compression;

namespace Plattar {
	public class PlattarExporterOptions {
		public static readonly string ZipExtension = ".zip";
		public static bool IsZip = true;
		public static string LastEditorPath = "";
		public static bool ExportAnimations = true;
		
		public static void CompressDirectory(string source, string destination) {
			// delete any files that exist
			PlattarExporterOptions.DeleteFile(destination + ZipExtension);

			// Compress a folder.
			ZipFile.CreateFromDirectory(source, destination + ZipExtension);
		}

		public static void DeleteFile(string target_file) {
			if (File.Exists(target_file)) {
			    File.SetAttributes(target_file, FileAttributes.Normal);
				File.Delete(target_file);
			}
		}
		
		public static void DeleteDirectory(string target_dir) {
			string[] files = Directory.GetFiles(target_dir);
			string[] dirs = Directory.GetDirectories(target_dir);
			
			foreach (string file in files) {
				File.SetAttributes(file, FileAttributes.Normal);
				File.Delete(file);
			}
			
			foreach (string dir in dirs) {
				DeleteDirectory(dir);
			}
			
			Directory.Delete(target_dir, false);
		}
	}
}
