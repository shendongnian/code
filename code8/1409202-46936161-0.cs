      public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc();
            services.AddApiVersioning();
         
            // remaining other stuff omitted for brevity
        }
