    private void ProcessEntities(IEnumerable<Entity> entities)
    {
        // some logic..
        // ...
        lock (processLock)
        {
            using (var transaction = SomeDbContext.Database.BeginTransaction())
            {
                try
                {
                    // process...
                    // ...
                    SomeDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Log(e);
                    throw;
                }
            }
        }
    }
    
