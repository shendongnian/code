        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<Db2Context>(((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var httpRequest = httpContext.Request;
                // Get the 'database' querystring parameter from the request (if supplied - default is empty).
               // TODO: Swap this out for an enum.
                var databaseQuerystringParameter = httpRequest.Query["database"].ToString();
                // Get the base, formatted connection string with the 'DATABASE' paramter missing.
                var db2ConnectionString = Configuration.GetConnectionString("IbmDb2Formatted");
                if (!databaseQuerystringParameter.IsNullOrEmpty())
                {
                    // We have a 'database' param, stick it in.
                    db2ConnectionString = string.Format(db2ConnectionString, databaseQuerystringParameter);
                }
                else
                {
                    // We havent been given a 'database' param, use the default.
                    var db2DefaultDatabaseValue = Configuration.GetConnectionString("IbmDb2DefaultDatabaseValue");
                    db2ConnectionString = string.Format(db2ConnectionString, db2DefaultDatabaseValue);
                }
                // Build the EF DbContext using the built conn string.
                options.UseDb2(db2ConnectionString, p => p.SetServerInfo(IBMDBServerType.OS390));
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "DB2 API",
                    Version = "v1"
                });
            });
        }
