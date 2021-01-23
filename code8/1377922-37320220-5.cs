        public class DocXManager: IDisposable
        {
            private readonly DocX docX;
            private bool disposed;
            public DocXManager(string filePath)
            {
                docX = new DocX(filePath);
            }
            public void MakeChangesAndSaveDocX()
            {
                 if (disposed) 
                    throw new ObjectDisposedException();
                 docX.Save();
            }
            public void FrobDocX(Frobber frobber)
            {
                if (disposed) 
                    throw new ObjectDisposedException();
                frobber.Frob(docX);
            }
            public void Dispose()
            {
                if (disposed)
                   return;
                Dispose(true);
                disposed = true;
                GC.SupressFinalize(this);   
            }
            public void Dispose(bool disposing)
            {
                if (disposing)
                {
                    //we can sefely dispose managed resources here
                    ((IDisposable)docX).Dispose();
                }
                //unsafe to clean up managed resources here, only clean up unmanaged resources if any.
            }
            ~DocXManager()
            {
                 Dispose(false);
            }
       } 
 
