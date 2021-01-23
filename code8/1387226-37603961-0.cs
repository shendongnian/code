    public List<string> GetFiles(string folder)
    {
        List<string> allFilesPaths = new List<string>();
        string[] allSubDirectories = System.IO.Directory.GetDirectories();
        for(int i = 0;i<allSubDirectories.Length; i++)
        {
           //you may need to format this path a bit but this is the magic of 
          //recursion, its calling itself!
           List<string> subfiles = GetFiles(folder + allSubDirectories[i]); 
           allFilesPaths.AddRange(subfiles);
        }
        string[] allFiles = System.IO.Directory.GetFiles(folder);
        //You may need to append the entire path onto each file if you want
        allFilesPaths.AddRange(allFiles);
        return allFilesPaths;
    }
    Main()
    {
       string RootDirectoryPath = "...";
       List<string> allFilesPaths = GetFiles(RootDirectoryPath );
       //copy each file one by one
    }
