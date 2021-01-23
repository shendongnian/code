    private static Mutex mutex;
    public void WriteFile(string path)
    {
        Mutex mutex = GetOrCreateMutex();
        try
        {
            mutex.WaitOne();
            // TODO: ... write file
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
    public byte[] ReadFile(string path)
    {
        // Note: If you just read the file, this lock is completely unnecessary
        // because ReadAllFile uses Read access. This just protects the file
        // being read and written at the same time
        Mutex mutex = GetOrCreateMutex();
        try
        {
            mutex.WaitOne();
            return File.ReadAllBytes(path);
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
    private static Mutex GetOrCreateMutex()
    {
        try
        {
            mutex = Mutex.OpenExisting("MyMutex");
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            mutex = new Mutex(false, "MyMutex");
        }
    }
