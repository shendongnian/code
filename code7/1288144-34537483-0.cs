    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        this.Seed();
    }
    
    private void Seed()
    {
        using (var db = new MyDbContext())
        {
            db.Database.Migrate();
            
            // Seed code
            
            db.SaveChanges();
        }
    }
