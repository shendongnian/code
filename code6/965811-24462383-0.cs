    private void OnDataReceived(object sender, DataReceivedEventArgs e) {
      if (!String.IsNullOrEmpty(e.Data)) {
        backgroundWorker1.ReportProgress(1, e.Data);
        System.Threading.Thread.Sleep(300);
      }
    }
