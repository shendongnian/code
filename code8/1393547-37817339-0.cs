        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(c =>
            {
                // TODO implement this abstract class c.Filters.Add(typeof(ExceptionFilterAttribute));
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                c.Filters.Add(new AuthorizeFilter(policy));
                c.Filters.Add(typeof(ValidateModelFilter));
            });
