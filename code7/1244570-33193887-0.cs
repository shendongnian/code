    private async void btnStart_Click(object sender, RoutedEventArgs e)
    {
        WorkerClass wItem = new WorkerClass();
        wItem.ProgressUpdate += (s, eArg) => {
            Dispatcher.BeginInvoke((Action)delegate() { txtProgress.Text = wItem.currentIteration.ToString(); });
        };
        Task task = Task.Run(wItem.Process);
        // MessageBox.Show("Job started...");
        await task;
        MessageBox.Show("Job is done!");
    }
