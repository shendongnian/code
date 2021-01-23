    private ICommand _printCommand;
            public ICommand PrintCommand
            {
              get
              {
                return _printCommand ??(PrintCommand=
                       new RelayCommand(async () => await PrintReceipt(), CanExecute));
                }
            }
    //Determine can execute command
    private bool CanExecute()
    {
          return !isbusy;
    }
