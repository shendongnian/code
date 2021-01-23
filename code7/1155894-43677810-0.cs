        public readonly DatabaseContext _context;
        private readonly IDbTransaction _transaction;
        private readonly ObjectContext _objectContext;
          public UnitOfWork(DatabaseContext context)
        {
            _context = context as DatabaseContext ?? new DatabaseContext ();
            this._objectContext = ((IObjectContextAdapter)this._context).ObjectContext;
            if (this._objectContext.Connection.State != ConnectionState.Open)
            {
                this._objectContext.Connection.Open();
                this._transaction = _objectContext.Connection.BeginTransaction();
            }
          }             
        public int Complete()
        {
            int result = 0;
            try
            {
                result = _context.SaveChanges();
                this._transaction.Commit();
            }
            catch (Exception ex)
            {
                Rollback();
            }
            return result;
        }
        private void Rollback()
        {
            this._transaction.Rollback();
            foreach (var entry in this._context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case System.Data.Entity.EntityState.Modified:
                        entry.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    case System.Data.Entity.EntityState.Added:
                        entry.State = System.Data.Entity.EntityState.Detached;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        entry.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                }
            }
        }
        public void Dispose()
        {
            if (this._objectContext.Connection.State == ConnectionState.Open)
            {
                this._objectContext.Connection.Close();
            }
            _context.Dispose();
        }
    }
