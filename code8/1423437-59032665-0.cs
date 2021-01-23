     // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers().AddJsonOptions(jsonOptions =>
                    {
                        jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                    })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0); ;
            }
