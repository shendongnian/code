    private ActionCommand<string> _magnifyMinimiseCommand;
    public MainWindow()
    {
        _magnifyMinimiseCommand = new ActionCommand<string>(Magnify);
        ....
    }
    private void Magnify(string stretch)
    {
        // now the viewmodel handles it instead of the action
        Stretch = stretch;
    }
