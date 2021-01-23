    public void Configure(Seeder seeder)
    {
        //Edited due to typo/bad syntax.
        ConfigureAsync(seeder).Wait();
    }
    public async Task ConfigureAsync(Seeder seeder)
    {
       //Now treat this like true async/await.
       await seeder.Seed().ConfigureAwait(false);
    }
