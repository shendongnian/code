    private CancellationTokenSource cts; //MainForm instance field
    private async void processingButton_Click(object sender, EventArgs e)
    {
        if (!this.isStarted)
        {
            this.cts = new CancellationTokenSource();
            this.processingButton.Text = "Cancel";
            this.isStarted = true;
            var progressIndicator = new Progress<int>(this.ReportProgress);
            try
            {
                await this.ProcessLongRunningOperationAsync(progressIndicator, this.cts.Token);
                MessageBox.Show("Completed!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Cancelled!");
            }
            this.ResetUI();
        }
        else
        {
            this.cts.Cancel();
            this.processingButton.Text = "Start";
            this.isStarted = false;
        }
    }
