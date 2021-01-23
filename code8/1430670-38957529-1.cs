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
            if (semaphore.CurrentCount == 0)
            {
                return;
            }
            Console.WriteLine(semaphore.CurrentCount);
            bool busy = await semaphore.WaitAsync(1);
                
            await DoSomeStuff();
    
            await Task.Delay(TimeSpan.FromSeconds(5));
            semaphore.Release();
        }
    }
