    public void ButtonClick()
    {
       // Since your code will now be async, you should need to handle reentrance here
       var worker = new BackgroundWorker();
       worker.ReportsProgress = true;
       worker.ProgressChanged += ProgressLog;
       worker.DoWork += TestComm;
       worker.RunWorkerAsync();
    }
    
    private void ProgressLog(object sender, ProgressChangedEventArgs e)
    {
      richTextBox1.AppendText(e.UserState.ToString() + Environment.NewLine);
    }
    private void TestComm(object sender, DoWorkEventArgs e)
    {         
      var worker = sender as BackgroundWorker;
      worker.ReportProgress(0, "Starting Process.....");
      worker.ReportProgress(0, "COMMAND 1 " + (comm.WriteData(cmd1) == 0 ? "OK" : "NOT OK"));
      worker.ReportProgress(0, "Gathering signal from product sensor.....");
      worker.ReportProgress(0, "COMMAND 2 " + (comm.WriteData(cmd2) == 0 ? "OK" : "NOT OK"));
      worker.ReportProgress(0, "Measuring current value");
      worker.ReportProgress(0, "COMMAND 3 " + (comm.WriteData(cmd3) == 0 ? "OK" : "NOT OK"));
      // etc.
    }
