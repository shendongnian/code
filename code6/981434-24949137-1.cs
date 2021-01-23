    public class Class2
    {
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private bool? foo;
        private async Task<bool> GetFoo()
        {
            bool fooValue;
            // Atomic operation to get current foo
            bool? currentFoo = this.foo;
            if (currentFoo.HasValue)
            {
               Console.WriteLine("Foo already retrieved");
               fooValue = currentFoo.Value;
            }
           else
           {
               await semaphore.WaitAsync();
               {
                   // Atomic operation to get current foo
                   currentFoo = this.foo;
                   if (currentFoo.HasValue)
                   {
                      // Foo was retrieved while waiting
                       Console.WriteLine("Foo retrieved while waiting");
                       fooValue = currentFoo.Value;
                   }
                  else
                  {
                      // Simulate waiting to get foo value
                      Console.WriteLine("Getting new foo");
                      await Task.Delay(TimeSpan.FromSeconds(5));
                      this.foo = true;
                      fooValue = true;
                  }
              }
            semaphore.Release();
        }
        return fooValue;
    }
    
