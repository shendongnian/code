    public void Save()
    {
        var context = new AADataEntities();
        // Make changes to the context here...
        context.SaveChanges();
    }
    private ICommand _saveCommand = new DelegateCommand(Save);
    public ICommand SaveCommand
    {
        get { return _saveCommand; }
    }
