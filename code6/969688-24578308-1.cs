    class SomeClass : SomeDisposableBase
    {
       private readonly AsyncLazy<Thing> theThing = new AsyncLazy<Thing>(() => new Thing());
    protected override void Dispose(bool disposing)
    {
        if (disposing && theThing.IsValueCreated)
        {
            // Dispose Thing
        }
        base.Dispose(disposing);
     }
    }
