    public static PageBuffer Open(string path, Size maxSize, int cacheSize = DefaultCacheSize)
    {
    	return new PageBuffer(File.OpenRead(path), maxSize, cacheSize);
    }
    
    private PageBuffer(Stream stream, Size maxSize, int cacheSize)
    {
        // ...
    } 
