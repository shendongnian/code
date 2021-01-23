    private void Form2_Load(object sender, EventArgs e)
    {
        getto();
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.ProgressChanged -= backgroundWorker1_ProgressChanged;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        backgroundWorker1.RunWorkerCompleted -= backgroundWorker1_Completed;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_Completed;
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        using (var wc = new WebClient())
        {
            wc.DownloadProgressChanged += (sender, e) => backgroundWorker1.ReportProgress(sender, e);
            using (var stream = wc.OpenRead("http://avatar.nimbuzz.com/getAvatar?jid=" + textBox1.Text))
            {
                e.Result = (Image.FromStream(stream));
            }
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        progressBarX1.Value = e.ProgressPercentage;
        progressBarX1.Refresh();
    }
    private void backgroundWorker1_Completed(object sender, DoWorkEventArgs e)
    {
        pictureBox1.Image = e.Result;
    }
