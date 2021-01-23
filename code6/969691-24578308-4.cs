    class SomeClass : SomeDisposableBase
    {
       public SomeClass()
       {
          theThing = new AsyncLazy<Thing>(() => 
          { 
             _isInitialized = true;
             return new Thing();
          } 
       }
       private bool _isInitialized;
       private readonly AsyncLazy<Thing> theThing;
    protected override void Dispose(bool disposing)
    {
        if (disposing && _isInitialized)
        {
            // Dispose Thing
        }
        base.Dispose(disposing);
     }
    }
