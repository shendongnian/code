    public MainWindowViewModel(ILocalizer localizer)
    {
        _localizer = localizer;
        UC1ViewModel  = new UserControl1ViewModel(localizer); // <-- ouch
    }
