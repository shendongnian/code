       public class DocXManager: IDisposable
       {
            public static DoxXManager CreateManager(string filePath)
            {
                return new DocXManager(string filePath); 
            }
            private readonly DocX docX;
            private bool disposed;
            private DocXManager(string filePath)
            {
                docX = new DocX(filePath);
            }
            public void MakeChangesAndSaveDocX()
            {
                 if (disposed) 
                    throw new ObjectDisposedException();
                 docX.Save();
            }
            public void FrobDocx(Frobber frobber)
            {
                frobber.Frob(docX);
            }
            public void Dispose()
            {
                Dispose(true);
                disposed = true;
                GC.SupressFinalize(this);
            }
            public void Dispose(bool disposing)
            {
                if (disposing)
                {
                    //we can sefely dispose manager resources here
                    ((IDisposable)docX).Dispose();
                }
                //unsafe to clean up manager resources here, only clean up unmanaged resources if any.
            }
            ~DocXManager()
            {
                 Dispose(false);
            }
       } 
 
