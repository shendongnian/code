    private Process _exeProcess;
    private void btnExecute_Click(object sender, EventArgs e)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.CreateNoWindow = true;
        startInfo.FileName = Application.StartupPath + "\\Deps\\ats.exe";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
    
        _exeProcess = Process.Start(startInfo);
        _exeProcess.OutputDataReceived += exeProcess_OutputDataReceived;
        _exeProcess.BeginOutputReadLine();    
        _exeProcess.Exited += ContinueOnYourWay;
    }
    private void ContinueOnYourWay(object sender, EventArgs e) 
    {
        // Clean up
        _exeProcess.Dispose();
        _exeProcess = null;
        // More code here
    }
    
    private void exeProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (txtOutput.InvokeRequired)
        {
            txtOutput.Invoke(new MethodInvoker(delegate { txtOutput.Text += Environment.NewLine + e.Data; }));
        }
     }
