    class SomeClass : SomeDisposableBase
    {
       private bool _isInitialized;
       private readonly AsyncLazy<Thing> theThing = new AsyncLazy<Thing>(
       {
          _isInitialized = true;
          return new Thing();
       });
    protected override void Dispose(bool disposing)
    {
        if (disposing && _isInitialized)
        {
            // Dispose Thing
        }
        base.Dispose(disposing);
     }
    }
