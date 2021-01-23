    var progress = new MyProgressForm();
    progress.Show();
    MyWorker.RunWorkerAsync();
    ...
    ...
    
    private void MyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // log the exception
            MessageBox.Show("Error Uploading Data. See log for details.",
                            "Database Submission Error", MessageBoxButtons.OK);
            // we're back on the UI thread, so we can touch UI elements
            progress.Close();
            return;
        }
        // stuff to do if no error occurred
        ...
    }
