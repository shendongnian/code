    public void DeleteDirectoryFolders(DirectoryInfo dirInfo, bool ignoreIfFailed = false){
        foreach (DirectoryInfo dirs in dirInfo.GetDirectories()) 
        {
            try
            {
                dirs.Delete(true); 
            }
            catch (IOException)
            {
                if (!ignoreIfFailed)
                {
                    throw;
                }
            }
        } 
    }
    public void DeleteDirectoryFiles(DirectoryInfo dirInfo, bool ignoreIfFailed = false) {
        foreach(FileInfo files in dirInfo.GetFiles()) 
        { 
            try
            {
                files.Delete(); 
            }
            catch (IOException)
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
