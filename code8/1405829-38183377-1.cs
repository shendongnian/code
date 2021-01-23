    public override int SaveChanges()
    {
      DateTime saveTime = DateTime.Now;
      foreach (var entry in this.ChangeTracker.Entries()
          .Where(e => e.State == (EntityState) System.Data.EntityState.Added))
       {
         if (entry.Property("CreatedDate").CurrentValue == null)
           entry.Property("CreatedDate").CurrentValue = saveTime;
       }
       return base.SaveChanges();  
    }
