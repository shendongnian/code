    public class MyCustomDbContext : DbContext
    {
        public override int SaveChanges()
        {
            EntityState[] states = 
               new EntityState[] { 
                  EntityState.Added, EntityState.Deleted, EntityState.Modified };
            // get all addded/deleted/modified entries
            foreach ( var entry in ChangeTracker.Entries() )
            {
                if ( entry.Entity is IEntityBase &&
                     states.Any( s => s == entry.State )
                    )
                {
                    IEntityBase e = (IEntityBase)entry.Entity;
                    // some properties are always set
                    e.ModifiedDate = DateTime.Now;
                    // other properties are set only for 
                    // entities in specific state
                    if ( entry.State == EntityState.Added )
                    {
                        e.CreatedDate = DateTime.Now;
                    }
                }
            }
            // save changes
            return base.SaveChanges();
        }
     }
