    foreach (Process p in Process.GetProcessesByName("EXCEL"))
    {
        try
        {
            p.Kill();
            p.WaitForExit();
        }
        catch
        {
            //Handle exception here
        }
    }
