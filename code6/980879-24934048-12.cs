    private void Search()
    {
        backgroundWorker1.RunWorkerAsync(textBox1.Text);
    }
    ...
    backgroundWorker1.WorkerSupportsCancellation = true;
    backgroundWorker1.Completed += (sender, e) {
        if (e.Cancelled) {
            // restart background worker 
            Search();
        }
    };
    ...
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (backgroundWorker1.IsBusy) {
            backgroundWorker1.CancelAsync();
        } else {
            Search();
        }
    }
