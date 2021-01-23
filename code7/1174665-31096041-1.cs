        internal DbContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(DbContext _context)
        {
            this.context = _context;
            this.dbSet = context.Set<TEntity>();
        }
