    public TestClass
    {
         private Random random = new Random(DateTime.UtcNow.Millisecond);
         public Task<int> GetRandomNumber() 
         {
             return Task.FromResult(random.Next(0, 1500));
         }
    }
