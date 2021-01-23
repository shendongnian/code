    private void KillProcessByProcessName(string strProcessName)
    {
        foreach (Process p in System.Diagnostics.Process.GetProcessesByName(strProcessName))
            p.Kill();
    }
