    public void Configure(Seeder seeder)
    {
       ConfigureAsync(seeder).ConfigureAwait(false).Wait();
    }
    public async Task ConfigureAsync(Seeder seeder)
    {
       //Now treat this like true async/await.
       await seeder.Seed();
    }
