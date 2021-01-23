    private void MyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // We're back on the UI thread, so we can touch UI elements
        if (e.Error != null)
        {
            MessageBox.Show("Error Uploading Data. See log for details.",
                            "Database Submission Error", MessageBoxButtons.OK);
            // Close form
            progress.Close();
            return;
        }
        // stuff to do if no error occurred
        ...
    }
