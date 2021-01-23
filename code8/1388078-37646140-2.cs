    public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
            services
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserStore<MyOwnUserStore>()  // <----MOVED AFTER ADDING EF STORES
                .AddDefaultTokenProviders()
    
            services.AddMvc();
    
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
    }
