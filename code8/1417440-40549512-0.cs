    public class Program
    {
        public static ManualResetEventSlim Done = new ManualResetEventSlim(false);
        public static void Main(string[] args)
        {
            //This is unbelievably complex because .NET Core Console.ReadLine() does not block in a docker container...!
            var host = new WebHostBuilder().UseStartup(typeof(Startup)).Build();
            
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                Action shutdown = () =>
                {
                    if (!cts.IsCancellationRequested)
                    {
                        Console.WriteLine("Application is shutting down...");
                        cts.Cancel();
                    }
                    Done.Wait();
                };
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    shutdown();
                    // Don't terminate the process immediately, wait for the Main thread to exit gracefully.
                    eventArgs.Cancel = true;
                };
                host.Run(cts.Token);
                Done.Set();
            }
        }      
    }
