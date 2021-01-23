    public static class Extensions
    {
        public static ObservableCollection<TEntity> GetLocal<TEntity>(this DbSet<TEntity> set)
            where TEntity : class
        {
            var context = set.GetService<DbContext>();
            var data = context.ChangeTracker.Entries<TEntity>().Select(e => e.Entity);
            var collection = new ObservableCollection<TEntity>(data);
    
            collection.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    context.AddRange(e.NewItems.Cast<TEntity>());
                }
    
                if (e.OldItems != null)
                {
                    context.RemoveRange(e.OldItems.Cast<TEntity>());
                }
            };
    
            return collection;
        }
    }
