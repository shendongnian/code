    public string TryReadFile(string path, int maxTry)
    {
        Exception e;
        for (int i = 0; i < maxTry; i++)
        {
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (IOException io)
            {
                e = io;
                Thread.Sleep(100);
            }
        }
        
        throw e; // or just return null
    }
