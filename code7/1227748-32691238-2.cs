    public partial class MyDBContext 
    {
        public bool HasUnsavedChanges
        {
            get
            {
                try
                {
                    return this.ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                              || e.State == EntityState.Modified
                                                              || e.State == EntityState.Deleted);
                }
                catch (System.InvalidOperationException)
                {
                    return false;
                }
            }
        }
