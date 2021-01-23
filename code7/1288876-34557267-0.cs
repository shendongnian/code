    public static List<string> GetFilePaths(string dir)
    {
        var dirs = Directory.GetDirectories(dir);
        var returnList = new List<string>();
        
        if (dirs.Count() > 0)
        {
            foreach (var pwd in dirs)
            {
                returnList.AddRange(GetFilePaths(pwd));
            }
        }
        returnList.AddRange(Directory.GetFiles(dir));
        return returnList;
    }
