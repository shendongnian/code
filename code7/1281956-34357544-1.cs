    async private void button1_Click(object sender, EventArgs e)
    {
        // change visiiblity here...
        this.label1.Visible = true;
        // this work will happen on separate thread,
        // so the UI thread will be free to update the label visibility
        Progress<int> progress = new Progress<int>(percentage => this.progressBar1.Value = percentage);
        await Task.Run(() => this.WorkToBePerformedOnSeparateThread(progress));
        this.label1.Visible = false;
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
