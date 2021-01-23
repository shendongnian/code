    public void DeleteDirectoryFolders(DirectoryInfo dirInfo, bool ignoreIfFailed = false){
        foreach (DirectoryInfo dirs in dir.GetDirectories()) 
        {
            try
            {
                dirs.Delete(true); 
            }
            catch (Exception)
            {
                if (!ignoreIfFailed)
                {
                    throw;
                }
            }
        } 
    }
    public void DeleteDirectoryFiles(DirectoryInfo dirInfo, bool ignoreIfFailed = false) {
        foreach(FileInfo files in dir.GetFiles()) 
        { 
            try
            {
                files.Delete(); 
            }
            catch (Exception)
            {
                if (!ignoreIfFailed)
                {
                    throw;
                }
            }
        } 
    }
    public void DeleteDirectoryFilesAndFolders(string dirName, bool ignoreIfFailed = false) {
      DirectoryInfo dir = new DirectoryInfo(dirName); 
      DeleteDirectoryFiles(dir, ignoreIfFailed);
      DeleteDirectoryFolders(dir, ignoreIfFailed);
    }
