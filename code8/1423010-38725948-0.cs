    Mapper.Initialize( cfg => {
        cfg.CreateMap<PriceList, PriceListDTO>()
           .ReverseMap();
        // Not sure if this is required if you already have the model/dto map 
        cfg.CreateMap<IList<PriceList>, IList<PriceListDTO>>();
        cfg.AssertConfigurationIsValid();
    });
