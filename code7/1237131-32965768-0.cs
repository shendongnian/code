    public class UnitOfWork : IDisposable
        {
            private DbContext context = new DbContext();
            private RepositoryBase<TestataFatturaImmediataVendita> testataFatturaImmediataVenditaRepository;
            private RepositoryBase<TestataFatturaImmediataVendita1> testataFatturaImmediataVenditaRepository1;
            continued......
    
            public GenericRepository<TestataFatturaImmediataVendita> testataFatturaImmediataVenditaRepository
            {
                get
                {
    
                    if (this.testataFatturaImmediataVenditaRepository == null)
                    {
                        this.testataFatturaImmediataVenditaRepository = new RepositoryBase<TestataFatturaImmediataVendita>(context);
                    }
                    return testataFatturaImmediataVenditaRepository;
                }
            }
    
            public void Save()
            {
                context.SaveChanges();
            }
    
            private bool disposed = false;
    
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                this.disposed = true;
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
