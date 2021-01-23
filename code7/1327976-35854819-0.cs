		private static void AddDirectoryToProject(string sourceDir, Project project)
		{
			var dir = new DirectoryInfo(sourceDir);
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				var virtualStart = file.FullName.IndexOf("sourcebinaries");
				var virtualPath = file.FullName.Substring(virtualStart);
				project.AddItemFast("Content", virtualPath, new List<KeyValuePair<string, string>>()
				{
					new KeyValuePair<string, string>("CopyToOutputDirectory", "PreserveNewest")
				});
				Console.WriteLine(virtualPath);
			}
			foreach (var subDir in dir.GetDirectories())
			{
				AddDirectoryToProject(subDir.FullName, project);
			}
		}
