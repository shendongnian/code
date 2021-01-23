    class DisposableTest : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose called");
        }
    }
    ...
    using (DisposableTest sw = new DisposableTest())
    {
        Thread.Sleep(20000);
    }
