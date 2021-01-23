    private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
    {
        bool flag = true;
        while(flag)
        {
            try
            {
                File.Move(e.FullPath, @"C:\NewLocation\" + e.Name);
                flag = false;
            }
            catch { }
        }
    }
