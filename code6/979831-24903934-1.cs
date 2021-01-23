    static long GetDirectorySize(string p)
    {
    	// 1.
    	// Get array of all file names.
    	string[] a = Directory.GetFiles(p, "*", SearchOption.AllDirectories);
    
    	// 2.
    	// Calculate total bytes of all files in a loop.
    	long b = 0;
    	foreach (string name in a)
    	{
    	    // 3.
    	    // Use FileInfo to get length of each file.
    	    FileInfo info = new FileInfo(name);
    	    b += info.Length;
    	}
    	// 4.
    	// Return total size
    	return b;
    }
