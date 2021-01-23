    private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // do additional processing with e.Data if this is what you desire
            ProgressBar.Dispatcher.Invoke(new Action(()=> { ProgressBar.Value=double.Parse(e.Data); }));
        }
