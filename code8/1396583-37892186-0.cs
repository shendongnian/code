    foreach (Process proc in Process.GetProcesses())
    {
        try
        {
            string exePath = proc.MainModule.FileName;
            // calculate hash
        }
        catch
        { }
    }
