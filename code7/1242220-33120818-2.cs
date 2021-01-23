    public void FormatDrive(char driveLetter)
    {
        //format /q /x G:
        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = "format";
        pProcess.StartInfo.Arguments = "/q /x " + driveLetter + ":";
        pProcess.StartInfo.UseShellExecute = false;
        //pProcess.StartInfo.RedirectStandardOutput = true;
        pProcess.StartInfo.CreateNoWindow = true;
        pProcess.Start();
        //string strOutput = pProcess.StandardOutput.ReadToEnd();
    }
