    public RelayCommand ButtonCommandNew
    {
        get
        {
            var worker = new TCService();
            return _buttonCommandNew
                   ?? (_buttonCommandNew = new RelayCommand(ExecuteAction, CanExecuteAction));
        }
    }
    private async void ExecuteAction()
    {
       var progress = new Progress<string>(status =>
        {
 	        ProgressText = status;
 	    });
 
        _inProgress = true;
        _buttonCommandNew.RaiseCanExecuteChanged();
        await worker.GenerateConfiguration(1, "", "", progress);
        _inProgress = false;
        _buttonCommandNew.RaiseCanExecuteChanged();
    }
    
    private bool CanExecuteAction() 
    {
        return !_inProgress;
    }
