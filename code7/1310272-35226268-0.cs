    int procCount = 0;
    Process[] processlist = Process.GetProcessesByName("OUTLOOK");
    foreach (Process theprocess in processlist)
    {
        procCount++;			
    }
     if (procCount > 0)
    {
      //outlook is open
    }
