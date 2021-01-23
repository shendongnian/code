    private RelayCommand<string> _parentCommand;
    private string parameter;
    
    public RelayCommand<string> ParentCommand
    {
        get
        {
            if (_parentCommand == null)
            {
                _parentCommand = new RelayCommand<string>(parameter => child.ChildCommand.Execute(parameter));
    
            }
    
            return _parentCommand;
        }
    }
