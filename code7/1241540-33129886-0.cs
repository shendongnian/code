        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
                                            options
                                            .ConstraintMap
                                            .Add("constraintName", typeof(MyCustomConstraint)));
        }
