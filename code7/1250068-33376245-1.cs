    public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new DelegateCommand((obj)=>CloseApplication());
                }
                return exitCommand;
            }
        }
