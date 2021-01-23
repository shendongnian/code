    private void Foo()
    {
        Task.Run(() => NormalMethod());
    }
    private void NormalMethod()
    {
        string[] files = GetFilesFromDir(@"C:\Bar\");
        if (files == null || files.Length < 0) { return; }
    
        for (int i = 0; i < files.Length; i++)
        {
            tbSked.Text = files[i];
            LoadFile();
            SQLUpdate();
            RestartTimer();
        }
    }
