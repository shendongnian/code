        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton<IClaimsTransformer, ClaimsTransformer>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireClaim(ClaimTypes.Role, "Administrator"));
            });
            //...
        }
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult Index() { }
