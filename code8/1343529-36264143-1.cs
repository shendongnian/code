    void MyMethod
    {
       using(Process process = new Process()) {
         process.StartInfo.FileName = "cmd.exe";
         process.Start();
         if(!process.WaitForExit(10000)) // here we set a timeout of 10 seconds (time is in milliseconds)
             process.Kill(); // if you really want to stop the process, its still running here.
       }
    }
