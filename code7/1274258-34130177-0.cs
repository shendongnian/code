    [SetUp]
    public void Setup()
    {
        SetupAsync().Wait();
    }
    public async Task SetupAsync()
    {
        var db = new InMemoryDbContext();
        // ... add sample data in db context
        // ... then save them
        await db.SaveChangesAsync();
    }
