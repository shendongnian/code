    public Startup(IHostingEnvironment env)
    {
        using(var client = new DatabaseContext())
        {
            client.Database.EnsureCreated();
        }
    }
