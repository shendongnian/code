    private void Foo()
    {
        string[] files = GetFilesFromDir(@"C:\Bar\");
        if (files == null || files.Length < 0) { return; }
        new Thread(()=>{
          for(int i = 0; i < files.Length; i++)
          {
            tbSked.Text = files[i]; //if this one is a text box, dispatch it in the main thread.
            LoadFile();
            SQLUpdate();
            RestartTimer();
          }
        }).Start();
    }
