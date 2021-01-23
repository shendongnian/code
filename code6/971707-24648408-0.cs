    public static Application CreateApplicaiton(string siteName, string path, string physicalPath, string appPoolName)
		{
            ServerManager iisManager = ServerManager.OpenRemote(Environment.MachineName.ToLower());
			// should start with "/" also not to end with this symbol
			string correctApplicationPath = string.Format("{0}{1}", Path.AltDirectorySeparatorChar, path.Trim(Path.AltDirectorySeparatorChar));
		
			int indexOfApplication = correctApplicationPath.LastIndexOf(Path.AltDirectorySeparatorChar);
			if (indexOfApplication > 0)
			{
				// create sequence of virtual directories if the path is not a root level (i.e. test/beta1/Customer1/myApplication)
				string virtualDirectoryPath = correctApplicationPath.Substring(0, indexOfApplication);
				iisManager.CreateVirtualDirectory(siteName, virtualDirectoryPath, string.Empty);
			}
			Application application = iisManager.Sites[siteName].Applications.Add(correctApplicationPath, physicalPath);
			application.ApplicationPoolName = appPoolName;
			return application;
		}
