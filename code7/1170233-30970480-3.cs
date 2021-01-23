    public class SomeOtherClass : IDisposable
    {
      private SomeClass _someObj;
      public SomeOtherClass(string someIdentifier)
      {
        _someObj = new SomeClass(someIdentifier);
      }
      public void Dispose()
      {
        //If base type is disposable
        //call `base.Dispose()` here too.
        _someObj.Dispose();
      }
    }
