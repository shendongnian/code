    var diProjects = new DirectoryInfo(@"C:\Projects");
    var subFolders = diProjects.GetDirectories();
    for (var i = 0; i < subFolders.Length; i++)
    {
    	Console.WriteLine(string.Format("[{0}] {1}, directories = {2}, files = {3}"
    		, i
    		, subFolders[i].FullName
    		, subFolders[i].GetDirectories().Length
    		, subFolders[i].GetFiles().Length));
    }
