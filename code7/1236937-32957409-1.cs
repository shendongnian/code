    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        this.PerformTimeConsumingTask();
    }
    
    public void PerformTimeConsumingTask()
    {
        //Time-Consuming Task
        //When you need to update UI
        progressForm.Invoke(new Action(() =>
        {
            progressForm.ProgressValue = someValue;
        }));
    }
