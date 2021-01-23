    using System.Data.Entity.Infrastructure;
    
    //may be wrong syntax
    public bool SaveAllChanges()
    {
       var Changes = context.ChangeTracker.Entries()
                            .Where(e => e.State == EntityState.Modified | e.State == EntityState.Added | e.State ...);
       foreach(var change in Changes)
       {
         //check if you need to call your API
       }
       return context.SaveChanges() > 0 
    }
