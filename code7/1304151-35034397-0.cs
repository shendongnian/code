    public bool DirectoryIsGreatest(string directoryPath)
    {
      if (string.IsNullOrEmpty(path))
        return false;
      var parent = Directory.GetParent(directoryPath);
      if (parent == null)
        return false;
      var directoriesToCheck = Directory.GetDirectories(parent.FullName).ToList();
      directoriesToCheck.Sort();
      return directoriesToCheck[directoriesToCheck.Count - 1] == directoryPath;  
    }
