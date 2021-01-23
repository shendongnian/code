    public class FluentUnitOfWork : IDisposable
    {
        private DbContext Context { get; }
    
        private DbContextTransaction Transaction { get; set; }
    
        public FluentUnitOfWork(DbContext context)
        {
            Context = context;
        }
    
        public FluentUnitOfWork BeginTransaction()
        {
            Transaction = Context.Database.BeginTransaction();
            return this;
        }
    
        public FluentUnitOfWork DoInsert<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            return this;
        }
    
        public FluentUnitOfWork DoInsert<TEntity>(TEntity entity, out TEntity inserted) where TEntity : class
        {
            inserted = Context.Set<TEntity>().Add(entity);
            return this;
        }
    
        public FluentUnitOfWork DoUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Modified;
            return this;
        }
    
        public FluentUnitOfWork SaveAndContinue()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                // add your exception handling code here
            }
            return this;
        }
    
        public bool EndTransaction()
        {
            try
            {
                Context.SaveChanges();
                Transaction.Commit();
            }
            catch (DbEntityValidationException dbEx)
            {
                // add your exception handling code here
            }
            return true;
        }
    
        public void RollBack()
        {
            Transaction.Rollback();
            Dispose();
        }
    
        public void Dispose()
        {
            Transaction?.Dispose();
            Context?.Dispose();
        }
    }
