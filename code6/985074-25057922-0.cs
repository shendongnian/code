    private const string _lockFileName = @"c:\whatever\lock";
    private FileStream _lockFile;
    public bool Lock()
    {
        try
        {
            _lockFile = File.Open(_lockFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            return true;
        }
        catch { } // perhaps a certain exception type?
        return false;
    }
    public void Unlock()
    {
        if(_lockFile != null)
        {
            _lockFile.Close();
            File.Delete(_lockFileName);
            _lockFile = null;
        }
    }
