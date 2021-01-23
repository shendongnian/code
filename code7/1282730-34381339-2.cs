    private void ConvertNow(string cmd)
    {
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo.FileName = exepath;
        proc.StartInfo.Arguments = cmd;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.RedirectStandardOutput = true;
        // use this event
        proc.OutputDataReceived += (sender, e) => backgroundWorker1.ReportProgress(0, e.Data); // use this for synchronization
        proc.Start();
        // and start asynchronous read
        proc.BeginOutputReadLine();
        // wait until it's finished in your background worker thread
        proc.WaitForExit();
    }
