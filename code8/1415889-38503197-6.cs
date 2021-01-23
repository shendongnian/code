    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<SomeModel, SomeModelDetailsResponseModel>()
            .ForMember(r => r.UserName, c => c.MapFrom(o => o.User.FirstName + o.User.LastName));
    });
