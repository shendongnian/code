    public void ConfigureServices(IServiceCollection services)
    {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
            var idt = services.AddIdentity<ApplicationUser, IdentityRole>();        
            idt.AddEntityFrameworkStores<ApplicationDbContext>();
            idt.AddUserStore<MyOwnUserStore>();  // <----MOVED AFTER ADDING EF STORES
            idt.AddDefaultTokenProviders();
    
            services.AddMvc();
    
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
    }
