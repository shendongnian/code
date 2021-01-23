    public DbDisplayViewModel(IUserRepository repository)
    {
        this.UserRepository = repository;
        this.Load();
    }
