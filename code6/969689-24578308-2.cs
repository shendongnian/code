    class SomeClass : SomeDisposableBase
    {
       private bool _isInitialized;
       private readonly AsyncLazy<Thing> theThing = new AsyncLazy<Thing>(
       {
          () => new Thing();
          _isInitialized = true;
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
