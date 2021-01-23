    Process proc = new Process();
    ProcessStartInfo procInfo = new ProcessStartInfo()
    {
        FileName = "d:/test.exe",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };
                
    proc.StartInfo = procInfo;
    proc.EnableRaisingEvents = true;
    proc.Exited += (o, args) =>
    {
        MessageBox.Show(proc.StandardOutput.ReadToEnd());
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
