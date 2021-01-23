    async Task MainAsync()
    {
        IMongoCollection<ApplicationUser> userCollection = ...;
        var applicationUser = await userCollection.Find(_ => _.Id == inputId).SingleAsync();
    }
