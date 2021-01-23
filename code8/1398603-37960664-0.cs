    Process[] process = Process.GetProcesses();    
    foreach(Process theprocess in process)
    {
       if(theprocess.Length>0)
       {
           //process running
       }
       else
       {
          //not running
       }
    }
