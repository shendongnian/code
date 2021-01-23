    private void btnDoIt_Click(object sender, EventArgs e)
    {
        backgroundWorker.RunWorkerAsync();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        Foo();
    }
    
    int total = 0;
    private void Foo()
    {
        for (int i = 0; i <= 100000; i++)
        {
            total += i;
            this.Text = i.ToString();
        }
    }
    
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Run next process
    }
