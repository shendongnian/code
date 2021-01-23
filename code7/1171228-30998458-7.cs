    public void OnProgressChanged(object sender, ProgressChangedEventArgs args)
    {            
        this.Dispatcher.Invoke( () => SetProgress(args.ProgressPercentage) );
    }
    public void SetProgress(int progress)
    {      
        progressBar.Text = percent.ToString();
    }
