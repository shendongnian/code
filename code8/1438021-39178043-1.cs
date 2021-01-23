        BackgroundWorker bw = new BackgroundWorker();
    	WebClient webClient = new WebClient();
        bw.WorkerReportsProgress = true;
    
        //setup delegate for download progress changed. - runs in bw thread
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(delegate(object sender, DownloadProgressChangedEventArgs e)
        {
            // do something here every time the background worker is updated e.g. update download progress percentage ready to update progress bar in UI.
    		double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            int progress = int.Parse(Math.Truncate(percentage).ToString());
            bw.ReportProgress(progress);
        });
    
       //setup delegate for download backgroub worker progress changed. - runs in UI thread
        bw.ProgressChanged += new ProgressChangedEventHandler(delegate(object o, ProgressChangedEventArgs e)
        {
            // this thread has access to UI, e.g. take variable from above and set it in UI.
    		progressBar.Value = e.ProgressPercentage;
        });
    
        //setup delegate for download completion. - runs in bw thread
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(delegate(object sender, AsyncCompletedEventArgs e)
        {
            // do something here when download finishes
        });
    
        //setup delegate for backgroud worker finished. - runs in UI thread
        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate(object o, RunWorkerCompletedEventArgs e)
        {
            // do something here than needs to update the UI.
        });
    
        //MAIN CODE BLOCK for backgroud worker
        bw.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
        {
            // execute the main code here than needs to run in background. e.g. start download.
    		// this is where you would start the download in webClient. e.g. webClient.DownloadString("some url here");
        });
    
        bw.RunWorkerAsync();
