        private ICommand _executeCmdCommand;
        public ICommand ExecuteCmdCommand
        {
            get
            {
                if (_executeCmdCommand == null)
                {
                    _executeCmdCommand = new SimpleCommand((arg) =>
                    {
                        //Command logic goes here
                        ParseCommand(Command);
                        _historyPointer = -1;
                        _history.Insert(0, Command);
                        Command = "";
                    });
                }
                return _executeCmdCommand;
            }
        }
