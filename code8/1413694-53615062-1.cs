    var dbConnection = Effort.DbConnectionFactory.CreateTransient();
    using (var dbContext = new SchoolDbContext(dbConnection, true)
    {
          dbContext.Schools.Add(new School {...});
          dbConext.SaveChanges();
          // this database exists as long as the connection exists
          var schoolCount = dbContext.Schools.Count();
          // expect one school
    }
    // a new empty database will be created: there won't be any schools
    dbConnection = Effort.DbConnectionFactory.CreateTransient();
    using (var dbContext = new SchoolDbContext(dbConnection)
    {
         var schoolCount = dbContext.Schools.Count();
         // expect no schools
    }
