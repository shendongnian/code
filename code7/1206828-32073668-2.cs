      public abstract class Repository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext, new()
      public abstract class Repository<TEntity, TContext>
            where TEntity : class
            where TContext : class
    {
         private DbSet<TEntity> _set;
         public TContext ActiveContext { get; set; }
         public Repository(TContext dbContext)
         {
              ActiveContext = dbContext;
         }
         ....
    }
