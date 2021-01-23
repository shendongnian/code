	using Microsoft.Data.Entity;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	namespace MyProject
	{
	    public class Startup
	    {
	        public IConfigurationRoot Configuration { get; set; }
	        public Startup()
	        {
	            var builder = new ConfigurationBuilder()
	             .AddJsonFile("appsettings.json");
	            Configuration = builder.Build();
	        }
	        public void ConfigureServices(IServiceCollection services)
	        {
	            services.AddEntityFramework()
	                .AddSqlServer()
	                .AddDbContext<MyDbContext>(options =>
	                    options.UseSqlServer(Configuration["Data:MyDb:ConnectionString"]));
	        }
	    }
	}
