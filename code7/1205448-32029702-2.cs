    class A : IDisposable
    {
         public void Dispose()
         {
             ...
         }
    }
    class B : A, IDisposable
    {
         void IDisposable.Dispose()
         {
             base.Dispose();
         }
    }
