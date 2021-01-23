    public class MyDbContext : DbContext
    {
        //DataSets and what not.
        //...
        public void Rollback()
        {
            //Get all entities
            var entries = this.ChangeTracker.Entries().ToList();
            var changed = entries.Where(x => x.State != EntityState.Unchanged).ToList();
            var modified = changed.Where(x => x.State == EntityState.Modified).ToList();
            var added = changed.Where(x => x.State == EntityState.Added).ToList();
            var deleted = changed.Where(x => x.State == EntityState.Deleted).ToList();
            //Reset values for modified entries
            foreach (var entry in modified)
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }
            //Remove any added entries
            foreach (var entry in added)
                entry.State = EntityState.Detached;
            //Undo any deleted entries
            foreach (var entry in deleted)
                entry.State = EntityState.Unchanged;
        }
    }
