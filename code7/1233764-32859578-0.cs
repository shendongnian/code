    class A : IDisposable
    {
        public void Dispose()
        {
            // Dispose
        }
    }
    
    using (A a = new A())
    {
    
    }
