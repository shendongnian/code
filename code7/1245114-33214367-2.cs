    // Now IDisposable is redundant: there're no fields to dispose
    public class DirSearch : IDisposable {
      // All these three fields don't implement iDisposable thus they can't be disposed
      //TODO: change this field into (read-only) property
      public bool searchSuccessful;
      
      //TODO: change this field into (read-only) property 
      public string errStr;
      
      List<string> resList = new List<string>();
      // I've omitted some code
      ...
      
      // Property: you may want to know if the instance has been dispose or not
      public Boolean IsDisposed {
        get;
        protected set; // or even "private"
      }
      // "protected virtual" since this method should be able to be overridden in child classes
      protected virtual Dispose(Boolean disposing) {
        if (IsDisposed)
          return;
        if (disposing) {
          //TODO: Dispose unmanaged resources here
          // NO Dispose() call here! Beware Stack overflow
        }
        
        IsDisposed = true;
      }
      public Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    }
