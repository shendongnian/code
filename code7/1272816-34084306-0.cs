    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.OptionsModel;
    using System.Collections.Generic;
    namespace WebApplication1
    {
        public class Startup
        {
            public Startup(IHostingEnvironment env)
            {
                // Set up configuration sources.
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("extraData.json")
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
            }
            public IConfigurationRoot Configuration { get; set; }
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddOptions();
                services.Configure<List<ExtraData>>(Configuration.GetSection("ExtraData"));
            }
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                List<ExtraData> result = app.ApplicationServices.GetRequiredService<IOptions<List<ExtraData>>>().Value;
                // you should get what you need. It works in my computer with rc1 update 1
            }
            public static void Main(string[] args) => WebApplication.Run<Startup>(args);
        }
        public class ExtraData
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
    }
