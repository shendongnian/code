        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //create Autofac container build
            var builder = new ContainerBuilder();
            //populate the container with services here..
            builder.RegisterType<DemoService>().As<IProjectDemo>();
            builder.Populate(services);
            //build container
            var container = builder.Build();
            //return service provider
            return container.ResolveOptional<IServiceProvider>();
        }
