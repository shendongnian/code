    // read the file
    private string ReadFile(string path)
    {
        Monitor.Enter(this._locker);
        try
        {
            // read the file here...
        }
        finally
        {
            Monitor.Exit(this._locker);
        }
    }
