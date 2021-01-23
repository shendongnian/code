    public class CustomerEntity()
    {
        public string Name {get;set;}
    }
    
    
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<CustomerEntity>())
        {
            if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
            {
                // Possibly check for null or if it's changed at all.
                entry.Entity.Name = entry.Entity.Name.ToUpper();
            }
        }
        return base.SaveChanges();
    }
