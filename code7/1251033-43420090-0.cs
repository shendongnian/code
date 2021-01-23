    protected async void LoadData()
    {
        ProgressForm _progress = new ProgressForm();
        // 'await' long-running method by wrapping inside Task.Run
        await Task.Run(new Action(() =>
        {
            // Display dialog modally
            // - Use BeginInvoke here to avoid blocking
            //   and illegal cross threading exception
            this.BeginInvoke(new Action(() =>
            {   
                loadComponentDialog.ShowDialog();
            }));
            
            // Begin long-running method here
            GetData();
        })).ContinueWith(new Action<Task>(task => 
        {
            // Close modal dialog
            // - No need to use BeginInvoke here
            //   because ContinueWith was called with TaskScheduler.FromCurrentSynchronizationContext()
            _progress.Close();
        }), TaskScheduler.FromCurrentSynchronizationContext());
    }
