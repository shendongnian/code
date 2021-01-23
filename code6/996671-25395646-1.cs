    #region IDisposable implementation with finalizer
    private bool isDisposed = false;
    public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
    protected virtual void Dispose(bool disposing) {
      if (!isDisposed) {
        if (disposing) {
          if (_wplayer != null)     _wplayer.Dispose();
       }
      }
      isDisposed = true;
    }
    #endregion
