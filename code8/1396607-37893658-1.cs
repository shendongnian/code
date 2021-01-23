    private void startButton_Click(object sender, EventArgs e)
    {
        // ...
        if (!backgroundWorker1.IsBusy)
        {
            SetWorkerMode(true);
            backgroundWorker1.RunWorkerAsync();
        }
    }
    
    private void pauseresumeButton_Click(object sender, EventArgs e)
    {
        SetWorkerMode(pauseresumeButton.Text == "Resume");
    }
     
