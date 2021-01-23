    public static void RefreshItemsInProject(Project project, string projectPath)
    {
      foreach(string subDirectoryPath in Directory.EnumerateDirectories(projectPath))
        AddItemsToProjectFromDirectory(project.ProjectItems, subDirectoryPath));
    }
    private static readonly HashSet<string> _excluded = new HashSet<string>() { "bin", "obj" };
    public static void AddItemsToProjectFromDirectory(ProjectItems projectItems, string directoryPath)
    {
      //very weird GetDirectoryName returns the FULL PATH!!!! 
      //When using GetFileName on a Directory it actually returns the FolderName WITHOUT the PATH.
      var directoryName = Path.GetFileName(directoryPath);
      if(_excluded.Contains(directoryName.ToLower()))//folder to exclude like bin and obj.
        return;//return right away if the folder has been excluded.
      var subFolder = projectItems.AddFromDirectory(directoryPath);
      foreach(string subDirectoryPath in Directory.EnumerateDirectories(directoryPath))
        AddItemsToProjectFromDirectory(subFolder.ProjectItems, subDirectoryPath);
    }
