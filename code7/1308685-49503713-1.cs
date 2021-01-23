    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                 // Add configuration, logging, ...
                .ConfigureServices((hostContext, services) =>
                {
                    // Better to use Dependency Injection for GreeterImpl
                    Server server = new Server
                    {
                        Services = {Greeter.BindService(new GreeterImpl())},
                        Ports = {new ServerPort("localhost", 5000, ServerCredentials.Insecure)}
                    };
                    services.AddSingleton<Server>(server);
                    services.AddSingleton<IHostedService, GrpcHostedService>();
                });
    
            await hostBuilder.RunConsoleAsync();
        }
    }
