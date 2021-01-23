    public class Startup
	{
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            // Register UserService a custom class which has access to the user profiles
			// This is injected.
            services.AddScoped<IUserService, UserService>();
			
			// Register the IAccountService which is injected in the controller
            services.AddScoped<IAccountService, AccountService>();
        }
	}
