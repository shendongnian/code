      public abstract class Repository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext, new()
      public abstract class Repository<TEntity, TContext>
            where TEntity : class
            where TContext : class
    {
         private DbSet<TEntity> _set;
         public DbContext ActiveContext { get; set; }
         protected Repository()
         {
              ActiveContext = (DbContext)TContext;
         }
         ....
    }
