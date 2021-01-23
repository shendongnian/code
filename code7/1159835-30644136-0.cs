    Process[] processlist = Process.GetProcesses();
    bool proccessRunning = false;
    foreach(Process theprocess in processlist){
       if( theprocess.Id == yourPID) 
       {
           proccessRunning = true;
           break;
       }        
    }
