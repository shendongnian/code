    try
    {
        Process p = Process.Start(startInfo);
        p.WaitForExit();
    }
    catch (Exception ex)
    {
        Log.Error("Zip Process Failed", ex);
        return false;
    }
