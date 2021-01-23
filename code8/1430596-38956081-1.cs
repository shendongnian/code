    private IEnumerable<Object> _someCollection;
    public ICommand CreateTheThingCommand
    {
        get { return new RelayCommand(CreateTheThing); }
    }
    private void CreateTheThing()
    {
        Object newObject = new Object(UI1.Text, UI2.Text, false);
        UI1.Text = string.Empty;
        UI2.Text = string.Empty;
        _someCollection = new List<Object> { newObject };
    }
