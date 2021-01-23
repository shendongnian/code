    public event EventHandler CanExecuteChanged
    {
       add { CommandManager.RequerySuggested += value; }
       remove { CommandManager.RequerySuggested -= value; }
    }
