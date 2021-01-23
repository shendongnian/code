    IMapper memberMapper = null;
    IMapper classMapper = null;
    var classConfig = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Source.Class, Target.Class>()
            .ForMember(t => t.Properties, opt => opt.MapFrom(s => memberMapper.Map<IList<Target.Property>>(s.Properties)))
            .ForMember(t => t.Definition, opt => opt.MapFrom(s => classMapper.Map<Source.Class, Target.Class>((Source.Class)s.Definition)));
        cfg.CreateMap<Source.Property, Target.Property>();
    });
    classConfig.AssertConfigurationIsValid();
    classMapper = classConfig.CreateMapper();
    var memberConfig = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Source.Member, Target.Member>()
            .Include<Source.Property, Target.Property>()
            .Include<Source.Parameter, Target.Parameter>()
            .ForMember(t => t.Definition, opt => opt.MapFrom(s => classMapper.Map<Source.Class, Target.Class>((Source.Class)s.Definition)));
        cfg.CreateMap<Source.Property, Target.Property>();
        cfg.CreateMap<Source.Parameter, Target.Parameter>();
    });
    memberConfig.AssertConfigurationIsValid();
    memberMapper = memberConfig.CreateMapper();
