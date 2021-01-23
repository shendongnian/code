    Process proc = new Process();
    ProcessStartInfo procInfo = new ProcessStartInfo()
    {
        FileName = "notepad.exe"
    };
                
    proc.StartInfo = procInfo;
    proc.EnableRaisingEvents = true;
    proc.Exited += (o, args) =>
    {
        MessageBox.Show("exited!");
    };
    proc.Start();
    
    if (proc.WaitForExit(3000))
    {
        MessageBox.Show("YES");
    }
    else
    {
        MessageBox.Show("NO");
    }
