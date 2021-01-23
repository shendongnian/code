    public class MyDbContext : DbContext
    {
       public delegate void ChangeEventHandler(object sender, ChangeEventArgs e);
       public event ChangeEventHandler ChangeEvent;
    
       public override int SaveChanges()
       {
           var result = base.SaveChanges();
    
           var entitiesAdded = this.ChangeTracker.Entries.Where(x => x.State == EntityState.Added);
           var entitiesRemoved = this.ChangeTracker.Entries.Where(x => x.State == EntityState.Deleted);
           var entitiesModified = this.ChangeTracker.Entries.Where(x => x.State == EntityState.Modified);
    
           ChangeEvent(this, new ChangeEventArgs(entitiesAdded, entitiesRemoved, entitiesModified));
           return result;
       }
    
    }
