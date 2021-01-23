    Process[] procs;
    procs = Process.GetProcessesByName("Name");
    // Test to see if the process is not responding. 
    if (!procs[0].Responding)
    {
      procs[0].CloseMainWindow();
      procs[0].WaitForExit();
      procs[0].Start();
    }
