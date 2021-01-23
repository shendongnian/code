     public class DatabaseFactory : Disposable, IDatabaseFactory {
        private XXDbContext dataContext;
        public ISefeViewerDbContext Get() {
            return dataContext ?? (dataContext = new XXDbContext());
        }
        protected override void DisposeCore() {
            if (dataContext != null) {
                dataContext.Dispose();
            }
        }
    }
