    public static Task<TEntity> GetByIdAsync<TEntity>( 
        this DbSet<TEntity> set, int id)  where TEntity : Base
    {
        return set.FirstOrDefaultAsync(e => e.Id == id);
    }
