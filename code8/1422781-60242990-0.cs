        public void ConfigureServices(IServiceCollection services)
        {
            //...
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddMvcCore();
            //...
        }    
