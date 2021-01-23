    Mapper.Initialize(cfg => {
    string userName = null;
    cfg.CreateMap<Source, Dest>()
        .ForMember(d => d.UserName, 
            opt => opt.MapFrom(src => userName)
        );
    });
