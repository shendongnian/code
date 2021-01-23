    public override int SaveChanges()
    {
       foreach (var e in ChangeTracker.Entries())
       {
           SaveHistory(e.Entity);
       }
       return base.SaveChanges();
    }
