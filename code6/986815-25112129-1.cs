    public ICommand LoginCommand
    {
       get
       {
          return new RelayCommand(() =>
          {
             ProcessStatus = Status.AUTHORIZING;
             DoSomething();
          });
       }
    }
    private Status _processStatus;
    public Status ProcessStatus
    {
       get { return _processStatus; }
       set
       {
          if (value ==_processStatus)
             return;
          _processStatus= value;
          RaisePropertyChanged("ProcessStatus");
       }
    }
