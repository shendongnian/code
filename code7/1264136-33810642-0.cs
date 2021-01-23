    class MyDisposable : IDisposable //Remove IDisposable to see the exception
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose called");
        }
    }
