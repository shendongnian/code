	int iCount = 0;
    getFileCount(_dirPath, ref iCount);
    private void getFileCount(string _path, ref int iCount )
    {          
        try
        {
            // gives error :Use of unassigned out parameter 'iCount' RED Underline
            iCount += Directory.GetFiles(_path).Length;
            foreach (string _dirPath in Directory.GetDirectories(_path))
                getFileCount(_dirPath, ref iCount);
        }
        catch { }
    }
