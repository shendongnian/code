    progressBar.Show();
    worker.RunWorkerAsync(openSolution);
    ...
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        var openSolution = (Solution)e.Argument;
        // Run long method (which can't touch the UI, or it'll throw an exception)
        openSolution.AnalyzeSolution();
    }
    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        progressBar.Hide();  // Hide progress bar when job complete
    }
