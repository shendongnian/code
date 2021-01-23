    async private void buttonAdd_Click(object sender, EventArgs e)
    {
        // ....
        //Showing progressPanel
        progressPanel.Visible = true;
        progressBar1.Minimum = 1;
        progressBar1.Value = 1;
        progressBar1.Step = 1;
        // this work will happen on separate thread,
        // so the UI thread will be free to update the panel visibility
        Progress<int> progress = new Progress<int>(percentage => progressBar1.Value = percentage);
        await Task.Run(() => this.WorkToBePerformedOnSeparateThread(progress));
        progressPanel.Visible = false;
    }
    private void WorkToBePerformedOnSeparateThread(IProgress<int> progress)
    {
        // do work...
        progress.Report(25); // Report 25% completed...
        // do more work
        progress.Report(50); // Report 50% completed...
        // more work
        progress.Report(75); // Report 75% completed...
        // etc...
    }
