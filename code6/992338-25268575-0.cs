    public void  WatchCurrentFile() 
    {
      // start working in a new thread
      var task = Task.Factory.StartNew(() => GetFile());
    
      task.ContinueWith(t =>
        { Caller.updateFile(t.Result); });
    }
    
    private string GetFile()
    {
      string currentFile = "";
      return currentFile;
      // Alternately update asp the label here.
    }
