        public IServiceProvider ConfigureServices(IServiceCollection services) // returns IServiceProvider !
        {
            // Add framework services.
            services.AddMvc();
            services.AddWhatever();
            //using StructureMap;
            var container = new Container();
            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.For<IPet>().Add(new Cat("CatA")).Named("A");
                config.For<IPet>().Add(new Cat("CatB")).Named("B");
                config.For<IPet>().Use("A"); // Optionally set a default
                config.Populate(services);
            });
            return container.GetInstance<IServiceProvider>();
        }
