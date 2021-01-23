    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyContext()
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.SavingChanges += (sender, args) =>
            {
                var now = DateTimeOffset.Now;
                foreach (var entry in this.ChangeTracker.Entries<IDatedEntity>())
                {
                    var entity = entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.Created = now;
                            entity.Updated = now;
                            break;
                        case EntityState.Modified:
                            entity.Updated = now;
                            break;
                    }
                }
                this.ChangeTracker.DetectChanges();
            };
        }
    }
