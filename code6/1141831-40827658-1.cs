    using (var context = new MyContext())
    {
       context.Database.Initialize(false);
    }
    Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("EFConnectionStringName");
