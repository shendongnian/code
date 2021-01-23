    Mapper.Initialize(cfg => cfg.CreateMap<Data.Car, Business.Car>());
    config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Data.Car, Business.Car>();
    });
    config.AssertConfigurationIsValid();
