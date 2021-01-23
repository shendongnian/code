    private IMyRepository repository;
    public MainWindowViewModel(IMyRepository repo)
    {
        this.repository = repo;
    }
    public Task SaveObject(MyObject obj)
    {
        return this.repository.Save(obj);
    }
