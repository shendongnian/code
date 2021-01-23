    public class Program
    {
        public static void Main(string[] args) 
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build()
                .ReloadOnChanged("appsettings.json");
            var services = new ServiceCollection();
            services.Configure<AppSettings>(configuration.GetSection("appsettings"));
            services.AddTransient<ICall, Call>();
            // add other services
            // after configuring, build the IoC container
            IServiceProvider provider = services.BuildServiceProvider();
            Program program = provider.GetService<Program>();
            // run the application, in a console application we got to wait synchronously
            program.Wait();
        }
        private readonly ICall callService;
        // your programs main entry point
        public Program(ICall callService) 
        {
            this.callService = callService;
        }
        public async Task Run()
        {
             HttpResponseMessage result = await call.GetHttpResponseMessageFromDeviceAndDataService();
             // do something with the result
        } 
    }
