    public TestClass
    {
         public Task<int> GetRandomNumber() 
         {
             return Task.FromResult(ThreadSafeRandom.Next());
         }
    }
