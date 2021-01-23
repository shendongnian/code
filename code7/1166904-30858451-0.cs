    public static int DirSearch(string root)
    {
    	int count = Directory.GetFiles(root, "*.tmp", SearchOption.TopDirectoryOnly).Count();
    	foreach (string dir in Directory.GetDirectories(root))
    	{
    		count += Directory.GetFiles(dir, "*.tmp", SearchOption.TopDirectoryOnly).Count();
    		count += DirSearch(dir);
    	}
    	
    	return count;
    }  
