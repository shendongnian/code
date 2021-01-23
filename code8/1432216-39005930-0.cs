    public void Add(Site obj)
    {
        using(var context = new SiteContext())
        {
            using(var dbContextTransaction = new context.Database.BeginTransaction())
            {
                try
                {
                    context.Sites.Add(obj);
                    context.Entry(obj).State = obj.Id == 0 ? EntityState.Added : EntityState.Modified;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }
    }
