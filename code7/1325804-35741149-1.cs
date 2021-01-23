    while (string.IsNullOrEmpty(proc.MainWindowTitle))
    {
        System.Threading.Thread.Sleep(100);
        proc.Refresh();
    }
    // Then active caller form...
    this.Activate();
