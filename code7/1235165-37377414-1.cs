    <!-- language: c# -->
		protected void Page_Load(object sender, EventArgs e)
		{
			var rootFolder = new FileManagerRootFolder
			{
				Name = "A Root Folder",
				Location = "~/App_Data/RootFolder1"
			};
		
			rootFolder.AccessControls.Add(new FileManagerAccessControl
			{
				Path = @"\",
				AllowedPermissions = FileManagerPermissions.Full
			});
		
			fileManager.RootFolders.Add(rootFolder);
		}
 
