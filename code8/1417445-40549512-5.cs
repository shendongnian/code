    public class ConsoleAppRunner : IServer
    {
        /// <summary>A collection of HTTP features of the server.</summary>
        public IFeatureCollection Features { get; }
        public ConsoleAppRunner(ILoggerFactory loggerFactory)
        {
            Features = new FeatureCollection();
        }
        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }
        /// <summary>Start the server with an application.</summary>
        /// <param name="application">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1" />.</param>
        /// <typeparam name="TContext">The context associated with the application.</typeparam>
        public void Start<TContext>(IHttpApplication<TContext> application)
        {
            //Actual program code starts here...
            Console.WriteLine("Demo app running...");
            Program.Done.Wait();        // <-- Keeps the program running - The Done property is a ManualResetEventSlim instance which gets set if someone terminates the program.
            
        }
    }
