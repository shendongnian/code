    public interface IBusinessEntityContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IBusinessEntity;
        int SaveChanges();
        // Add this
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class, IBusinessEntity;
    }
