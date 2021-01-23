    // The method is disposing of the object
    public class NotDisposable
    {
      public string GetString()
      {
        string result;
        // This is disposed by the time the method exists.
        using(var disposable new Disposable)
        {
          result = disposable.GetString()
        }
        return result;
      }
    }
    // This class has a field that it needs to dispose
    // so it inherites from IDisposable
    public class Disposable : IDisposable
    {
      private bool _isDisposed;
      private readonly IDisposable _somethingToManuallyDispose;
      public Disposable()
      {
        somethingToManuallyDispose = new SomethingImplementsIDisposable();
      }
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)  
      {
        if (disposing && !_isDisposed)
        {
          _isDisposed = true;
          // Dispose Managed Resources
          if (_somethingToManuallyDispose != null)
          {
            _somethingToManuallyDispose.Dispose();
          }
        }
      }
    }
