    void MyMethod
    {
        using (var process = new Process())
        {
            process.StartInfo.FileName = "cmd.exe";
            process.Start();
            process.WaitForExit(10); // here we set a timeout of 10 seconds
            
            //now here I'd like to check whether the process exited normally or
            //due to timeout.
            if (!process.HasExited)
            {
                // Do something.
            }
        }
    }
