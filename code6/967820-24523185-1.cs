    private List<Label> arrLabel = new List<Label>();
    private List<string> values = new List<string>(); 
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var bw = (BackgroundWorker)sender;
        for (int i = 0; i < 6; i++)
            bw.ReportProgress(0, i);
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var currentIndex = Convert.ToInt32(e.UserState);
        arrLabel[currentIndex].Text = values[0].ToString();
    }
