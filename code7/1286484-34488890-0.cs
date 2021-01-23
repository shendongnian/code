    class A : IDisposable
    {
       public void Dispose()
       { 
          GC.Collect();           
       }
    }
