    public static Container RegisterAutoMapper(this Container container)
    {
        var profiles = typeof(AutoMapperRegistry).Assembly.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t)).Select(t => (Profile)Activator.CreateInstance(t));
        var config = new MapperConfiguration(cfg =>
        {
            foreach (var profile in profiles)
            {
                cfg.AddProfile(profile);
            }
        });
        container.RegisterSingleton<MapperConfiguration>(() => config);
        container.RegisterSingleton<IMapper>(() => container.GetInstance<MapperConfiguration>().CreateMapper());
        return container;
    }
