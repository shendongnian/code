    internal class Program
    {
        private static void Main()
        {
            var cts = new CancellationTokenSource();
            var instance = new ChildClass();
            var task = Task.Factory.StartNew(() =>
                    Task.Factory.StartNew(() => instance.start(cts.Token)).Wait());
            cts.Cancel();
            task.Wait();
        }
    }
    public class ChildClass
    {
        public void start(CancellationToken token)
        {
            var parallelOptions = new ParallelOptions {CancellationToken = token};
            try
            {
                Parallel.For(0, 100000, parallelOptions, i =>
                {
                    // Do something
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("canceled");
            }
        }
    }
