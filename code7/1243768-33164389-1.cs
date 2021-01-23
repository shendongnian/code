    public class SkypeClass : IDisposable
        {
            private bool disposed;
        
            /// <summary>
            /// Construction
            /// </summary>
            public SkypeClass ()
            {
            }
        
            /// <summary>
            /// Destructor
            /// </summary>
            ~SkypeClass ()
            {
                this.Dispose(false);
            }
        
            /// <summary>
            /// The dispose method that implements IDisposable.
            /// </summary>
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
        
            /// <summary>
            /// The virtual dispose method that allows
            /// classes inherithed from this one to dispose their resources.
            /// </summary>
            /// <param name="disposing"></param>
            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        // Dispose managed resources here.
                    }
        
                    // Dispose unmanaged resources here.
                }
        
                disposed = true;
            }
        }
