    using (var db = new AppDataContext())
    {
       db.Database.SetInitializer(new AppDataContextInitializer());
       db.Database.Initialize(true);
    }
