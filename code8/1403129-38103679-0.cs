    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        IProgress<int> progress = new Progress<int>();
        progress.ProgressChanged += progress_ProgressChanged;
        await DoSomething(progress);
    }
    private void progress_ProgressChanged(object sender, int e)
    {
        if(e < 100)
        {
            ShowBusy(e);  //Show busy with progress percentage
        }
        else
        {
            HideBusy();
        }
    }
    private async Task DoSomething(IProgress<int> progress)
    {
        progress.Report(0)
        longMethod1();
        progress.Report(50)
        longMethod2();
        progress.Report(100)
    }
