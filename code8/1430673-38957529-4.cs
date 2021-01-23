    public class MyClass
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
    
        public async Task MethodA()
        {
            await semaphore.WaitAsync();
    
            await DoSomeStuff();
    
            semaphore.Release();
        }
    
        public async Task MethodB()
        {
            bool success = await semaphore.WaitAsync(1);
            if (!success)
                return;
                
            await DoSomeStuff();
    
            await Task.Delay(TimeSpan.FromSeconds(5));
            semaphore.Release();
        }
    }
