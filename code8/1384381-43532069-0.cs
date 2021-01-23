    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
    
        // You can actually use
        // Configuration.GetConnectionString("DefaultConnection") here instead to simplify the code
