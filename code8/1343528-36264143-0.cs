    void MyMethod
    {
       using(Process process = new Process()) {
         process.StartInfo.FileName = "cmd.exe";
         process.Start();
         if(!process.WaitForExit(10)) // here we set a timeout of 10 seconds
             process.Kill(); // if you really want to stop the process, its still running here.
       }
    }
