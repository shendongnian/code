    public static ObservableCollection<TEntity> Local<TEntity>(this DbSet<TEntity> set)
                where TEntity : class
    {
        var context = set.GetService<ICurrentDbContext>().Context;            
        ...
    }
