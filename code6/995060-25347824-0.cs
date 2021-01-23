    public class YourContext : DbContext
    {
        // dbsets
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<AccountType>()
                .Where(at => at.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                entry.State = EntityState.Unchanged;
            }
            return base.SaveChanges();
        }
    }
