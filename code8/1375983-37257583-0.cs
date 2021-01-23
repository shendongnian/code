    private void button1_Click(object sender, EventArgs e)
    {
        this.button1.Enabled = false;
        this.BGW1.RunWorkerAsync();
        this.BGW2.RunWorkerAsync();
        this.BGW3.RunWorkerAsync();
        this.BGW4.RunWorkerAsync();
    }
    private void BGW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        RefreshButtonState();
    }
    private void BGW2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        RefreshButtonState();
    }
    private void BGW3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        RefreshButtonState();
    }
    private void BGW4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        RefreshButtonState();
    }
    private void RefreshButtonState()
    {
        this.button1.Enabled = !this.backgroundWorker1.IsBusy && 
                               !this.backgroundWorker2.IsBusy && 
                               !this.backgroundWorker3.IsBusy && 
                               !this.backgroundWorker4.IsBusy;
    }
