    class CollectionOfDisposable : IDisposable {
        IList<IDisposable> Members {get;}
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~CollectionOfDisposable()  {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                foreach (IDisposable item in Members) {
                    item.Dispose();
                }
            }
        }
    }
