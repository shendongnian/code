		public static void CreateVirtualDirectory(this ServerManager iisManager, string siteName, string path, string physicalPath)
		{
			Site site = iisManager.Sites[siteName];
			//remove '/' at the beginning and at the end
			List<string> pathElements = path.Trim(Path.AltDirectorySeparatorChar).Split(Path.AltDirectorySeparatorChar).ToList();
			string currentPath = string.Empty;
			List<string> directoryPath = pathElements;
			//go through applications hierarchy and find the deepest one
			Application application = site.Applications.First(a => a.Path == Path.AltDirectorySeparatorChar.ToString());
			for (int i = 0; i < pathElements.Count; i++)
			{
				string pathElement = pathElements[i];
				currentPath = string.Join(Path.AltDirectorySeparatorChar.ToString(), currentPath, pathElement);
				if (site.Applications[currentPath] != null)
				{
					application = site.Applications[currentPath];
					if (i != pathElements.Count - 1)
					{
						directoryPath = pathElements.GetRange(i + 1, pathElements.Count - i - 1);
					}
				}
			}
			currentPath = string.Empty;
			foreach (string pathElement in directoryPath)
			{
				currentPath = string.Join(Path.AltDirectorySeparatorChar.ToString(), currentPath, pathElement);
				//add virtual directories
				if (application.VirtualDirectories[currentPath] == null)
				{
					//assign physical path of application root folder by default
					string currentPhysicalPath = Path.Combine(application.VirtualDirectories[0].PhysicalPath, pathElement);
					//if this is last element of path, use physicalPath specified on method call
					if (pathElement == pathElements.Last() && !string.IsNullOrWhiteSpace(physicalPath))
					{
						currentPhysicalPath = physicalPath;
					}
					currentPhysicalPath = Environment.ExpandEnvironmentVariables(currentPhysicalPath);
					if (!Directory.Exists(currentPhysicalPath))
					{
						Directory.CreateDirectory(currentPhysicalPath);
					}
					application.VirtualDirectories.Add(currentPath, currentPhysicalPath);
				}
			}
		}
