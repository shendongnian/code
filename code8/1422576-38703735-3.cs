    public void OnProcessExited(object sender, EventArgs e)
    {
         // Do what you want to do when the process exited.
    }
    public void StartProcess()
    {
        Process myProcess = Process.Start("myprogram.exe", "arguments");
        myProcess.EnableRaisingEvents = true;
        myProcess.Exited += OnProcessExited;
    }
