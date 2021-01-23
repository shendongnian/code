    public abstract class UnitOfWork : IDisposable {
        private DbContext _context;
        
        public UnitOfWork(DbContext context) {
            _context = context;
        }
        protected bool Commit() {
            // ... (Assuming this is calling _context.SaveChanges())
        }
        public bool Dispose() {
            _context.Dispose();
        }
    }
