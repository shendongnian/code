    public ICommand DoCommand
    {
       get
        {
            if (_DoCommand == null)
            {
                _DoCommand = new RelayCommand(Param => NewMethod(new Action(()=>DoIt())));
            }
            return _DoCommand;
        }
    }
    NewMethod(Action DoIt)   
    {
        Task.Factory.StartNew(() =>
        {
            DoIt.Invoke();
        });
    }
