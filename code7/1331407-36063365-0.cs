        protected override void Load(ContainerBuilder builder)
        {
            var profiles =
                from t in typeof (MapperModuleRegistration).Assembly.GetTypes()
                where typeof (Profile).IsAssignableFrom(t)
                select (Profile) Activator.CreateInstance(t);
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            builder.RegisterInstance(config).As<MapperConfiguration>();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
