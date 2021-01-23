    IEnumerable<string> getMatchingSubDir(string dirPath, string pattern)
    {
       List<string> matchingFolders = new List<string>();
       DirectoryInfo myDir = new DirectoryInfo(dirPath);
       foreach (var subDir in myDir.GetDirectories(pattern))
       {
           matchingFolders.AddRange(getMatchingSubDir(subDir.FullName, pattern));
       }
       return matchingFolders;
    }
