    public class MyFunctions
    {
        private readonly ISomeDependency _dependency;
        public MyFunctions(ISomeDependency dependency)
        {
            _dependency = dependency;
        }
        public Task DoStuffAsync([QueueTrigger("queue")] string message)
        {
            Console.WriteLine("Injected dependency: {0}", _dependency);
            return Task.FromResult(true);
        }
    }
