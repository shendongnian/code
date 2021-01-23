    public static bool CheckJavaInstallation()
    {
        try
        {
            //ProcessStartInfo procStartInfo = new ProcessStartInfo("java", " -version"); // Check that any Java installed
            //ProcessStartInfo procStartInfo = new ProcessStartInfo("java", "-d32 -version"); // Check that 32 bit Java installed
            ProcessStartInfo procStartInfo = new ProcessStartInfo("java", "-d64 -version"); // Check that 64 bit Java installed
    
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process proc = new Process {StartInfo = procStartInfo};
            proc.Start();
    
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();
            return proc.ExitCode == 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
