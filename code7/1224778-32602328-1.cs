	public class Program
	{
	    public void Main(string[] args)
	    {
	        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
	        // do whatever
	    }
	    private readonly IServiceProvider serviceProvider;
	    public IConfigurationRoot Configuration { get; private set; }
	    public Program(IApplicationEnvironment env, IServiceManifest serviceManifest)
	    {
	        Configuration =
	            new ConfigurationBuilder(Directory.GetCurrentDirectory())
	            .AddJsonFile("config.json") // add the file to your project
	            .AddEnvironmentVariables()
	            .Build();
	        var services = new ServiceCollection();
	        ConfigureServices(services);
	        serviceProvider = services.BuildServiceProvider();
	    }
	    private void ConfigureServices(IServiceCollection services)
	    {
	        var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];
	        
	        // Register EntityFramework 7
	        services.AddEntityFramework()
	            .AddSqlServer()
	            .AddDbContext<ApplicationDbContext>(options =>
	                options.UseSqlServer(connectionString));
	        // Register UserManager & RoleManager
	        services.AddIdentity<ApplicationUser, IdentityRole>()
	           .AddEntityFrameworkStores<ApplicationDbContext>()
	           .AddDefaultTokenProviders();
	        // UserManager & RoleManager require logging and HttpContext dependencies
	        services.AddLogging();
	        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
	    }
	}
