     bool processRunning = false;
     
     void timerTickMethod()
     {
        var procIsRunning = Process.GetProcessesByName("xyz.exe").Any();
        if(procIsRunning && !processRunning)
          ProcessIsStartedEvent(); // or directly minimize your app
        else if(!procIsRuning && processRunning)
          ProcessIsEndedEvent(); // or directly restore your app
        processRunning = procIsRunning;
     }
