    const string dbName = "MyDb"
    var dbConnection = Effort.DbConnectionFactory.CreatePersistent(dbName);
    using (var dbContext = new SchoolDbContext(dbConnection)
    {
          dbContext.Schools.Add(new School {...});
          dbContext.SaveChanges();
    }
    dbConnection = Effort.DbConnectionFactory.CreatePersistent(dbName);
    using (var dbContext = new SchoolDbContext(dbConnection)
    {
         var schoolCount = dbContext.Schools.Count();
         // expect the school you just added
    }
