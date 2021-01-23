    public void SingleInstanceHandler()
    {
        Process[] procList = Process.GetProcesses();
      
        foreach(Process proc in procList)
        {
          if (!string.IsNullOrEmpty(proc.MainWindowTitle))
          {
            if (proc.MainWindowTitle == windowTitle) 
            {
              //Show relevant message
              Application.Current.Shutdown();
            }
          }
        }
    }
