    var config = new MapperConfiguration(cfg =>
    {
        // Base class mapping..
        cfg.CreateMap<IAnimalBO, AnimalVM>()
            .Include<ITigerBO, TigerVM>()
            .Include<IBearBO, BearVM>();
        cfg.CreateMap<ITigerBO, TigerVM>();
        cfg.CreateMap<IBearBO, BearVM>();
    });
