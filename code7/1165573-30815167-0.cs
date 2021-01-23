    private void bkWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        Dictionary<string, string> inputs = e.Argument as Dictionary<string, string>;
        string newcmd = @"C:\mympeg.exe";
        BackgrounWorker instance = sender as BackgroundWorker;
        
        if (instance == null)
        {
           e.Cancel = true;
           return;
        }
        Process proc = new Process();
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.RedirectStandardInput = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
        proc.ErrorDataReceived += new DataReceivedEventHandler(ErrorOutputHandler);
        proc.Start();
        processes.Add(row, proc.Id.ToString());
        if (txtLog.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate { 
                txtLog.AppendText("Starting Process......\r\n");
                txtLog.AppendText("Command recieved: "+newcmd+"\r\n"); 
            });
        }
        else
        {
            txtLog.AppendText("Starting Process......\r\n");
            txtLog.AppendText("Command recieved: " + newcmd + "\r\n"); 
        }
        StreamWriter cmdStreamWriter = proc.StandardInput;
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();
        cmdStreamWriter.Write(newcmd);
        foreach (KeyValuePair<string, string> val in inputs )
        {
            cmdStreamWriter.Write(" " + val.Key + " " + val.Value);
            if(instance.CancellationPending)
            {
                break;
            }
        }
        cmdStreamWriter.Close();
        if (txtLog.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate { txtLog.AppendText("\r\nFinished Process.......\r\n"); });
        }
        else
        {
            txtLog.AppendText("\r\nFinished Process.......\r\n");
        }
        proc.Close();
    }
