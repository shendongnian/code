		private void CopyFiles(int numberOfFiles)
			{
				List<string> files = System.IO.Directory.GetFiles(@"C:\Users\rando\Desktop\A", "*").ToList();
				List<string> filesToCopy = files.Where(file => file.Contains("Test_Test")).Take(numberOfFiles);
				foreach (string file in filesToCopy)
				{
					// here we set the destination string with the file name
					string destfile = @"C:\Users\rando\Desktop\B\" + System.IO.Path.GetFileName(file);
					// now we copy the file to that destination
					System.IO.File.Copy(file, destfile, true);
				}
			}
