    static StuffEntities()
    {
        Database.SetInitializer<StuffEntities>(null); // or however you have it
        System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new CommandInterceptor());
    }
