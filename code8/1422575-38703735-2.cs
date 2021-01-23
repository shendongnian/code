    Process myProcess = Process.Start("myprogram.exe", "arguments");
    myProcess.EnableRaisingEvents = true;
    myProcess.Exited += (sender, e) => 
        {
           // Do what you want to do when the process exited.
        }
