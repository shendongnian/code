    private ICommand windowClosingCommand;
    public ICommand WindowClosingCommand
    {
        get { return windowClosingCommand ?? (windowClosingCommand = new RelayCommand(OnWindowClosing)); }
    }
    private void OnWindowClosing(object parameter)
    {
        CancelEventArgs cancelEventArgs = parameter as CancelEventArgs;
        if (cancelEventArgs != null)
        {
            // If you want to cancel the closing of the window you can call the following:
            //cancelEventArgs.Cancel = true;
        }
    }
