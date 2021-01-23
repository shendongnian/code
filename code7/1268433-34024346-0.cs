    public class MyApplicationDbContext : IdentityDbContext<MyApplicationUser>
    {
        //DbSets etc
        public virtual IEnumerable<MyModelBase> AddedEntries
        {
            get
            {				
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added))
                {
                    MyModelBase model = entry.Entity as MyModelBase;
                    if (model != null)
                    {
                        yield return model;
                    }
                }
            }
        }
    }
	
