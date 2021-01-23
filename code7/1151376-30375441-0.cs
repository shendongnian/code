    private void CboItemId_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // turn indicator ON
        ItemSearchBusyIndicator.IsBusy = true;
    
        var _backgroundWorker = new BackgroundWorker();
        _backgroundWorker.DoWork += backgroundWorker_DoWork;
        _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
        // start background operation;
        // direct call to backgroundWorker_DoWork just calls method synchronously
        _backgroundWorker.RunWorkerAsync();
    }
    private void _backgroundWorker_RunWorkerCompleted(/* I don't remember signature */)
    {
        // turn indicator OFF
        ItemSearchBusyIndicator.IsBusy = false;
         
        // other code
    }
