       private ICommand finishCommand;
      
            public ICommand FinishCommand
            {
                get
                {
                    if (this.finishCommand == null)
                    {
                        this.finishCommand = new RelayCommand<object>(this.ExecuteFinishCommand, this.CanExecutFinishCommand);
                    }
    
                    return this.finishCommand;
                }
            }
    
    private void ExecuteFinishCommand(object obj)
            {
    }
     private bool CanExecutFinishCommand(object obj)
            {
                return true;
            }
