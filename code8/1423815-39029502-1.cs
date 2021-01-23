    using System;
    
    class DerivedClass : BaseClass
    {
       // Flag: Has Dispose already been called?
       bool disposed = false;
    
       // Protected implementation of Dispose pattern.
       protected override void Dispose(bool disposing)
       {
          if (disposed)
             return; 
    
          if (disposing) {
             // Free any other managed objects here.
             //
          }
    
          // Free any unmanaged objects here.
          //
          disposed = true;
    
          // Call the base class implementation.
          base.Dispose(disposing);
       }
    
       // Only if there are unmanaged resources.
       ~DerivedClass()
       {
          Dispose(false);
       }
    }
