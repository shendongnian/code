    using (var ctx = new MyDbContext())
    {
        // begin a transaction in EF – note: this returns a DbContextTransaction object
        // and will open the underlying database connection if necessary
        using (var dbCtxTxn = ctx.Database.BeginTransaction())
        {
           try
           {
                // use DbContext as normal - query, update, call SaveChanges() etc. E.g.:
               ctx.Database.ExecuteSqlCommand(
                   @"UPDATE MyEntity SET Processed = ‘Done’ "
                   + "WHERE LastUpdated < ‘2013-03-05T16:43:00’");
               var myNewEntity = new MyEntity() { Text = @"My New Entity" };
               ctx.MyEntities.Add(myNewEntity);
               ctx.SaveChanges();
               dbCtxTxn.Commit();
           }
           catch (Exception e)
           {
               dbCtxTxn.Rollback();
           }
        } // if DbContextTransaction opened the connection then it will close it here
    }
