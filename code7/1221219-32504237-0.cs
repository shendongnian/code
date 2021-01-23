    this.progress.ProgressChanged += (s, e) =>
        {
            Dispatcher.BeginInovoke(() => {
                Debug.WriteLine("Progress: " + e.ProgressPercentage + "%");
                progressBar.Value += e.ProgressPercentage;
                txtResult.Text += e.Text;
            });
        };
