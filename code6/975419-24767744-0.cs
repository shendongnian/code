    public void OnExit() {
     try {
        foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
              if (myProc.ProcessName == "process name")
                myProc.Kill();
       } catch(Exception ex) {} 
     }
