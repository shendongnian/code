    public class UnitOfWork : IDisposable
        {
            private DbContext context = new DbContext();
            private FooRepository fooRepository;
    
            public FooRepository fooRepository
            {
                get
                {
    
                    if (this.fooRepository == null)
                    {
                        this.fooRepository = new FooRepository(context);
                    }
                    return fooRepository;
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
        }
