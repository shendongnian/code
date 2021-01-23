            public ICommand Command => new DelegateCommand<object>(ExecuteCommand);
    
            private void ExecuteCommand(object obj)
            {
                double width = (double)obj;
            }
