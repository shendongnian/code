    // put inside a static class
    public static Destination CustomMap(
        this IMapper mapper,
        SourceDto source,
        AnotherSourceDto anotherSource)
    {
        var destination = mapper.Map<Destination>(source);
        destination.DestValue3 =
            source.SourceValue3 + " " + anotherSource.AnotherSourceValue2;
        return destination;
    }
    void Main()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<SourceDto, Destination>()
                .ForMember(dest => dest.DestValue3, opt => opt.Ignore()));
        // usage
        var mapper = config.CreateMapper();
        var source = new SourceDto { /* add properties */ };
        var anotherSource = new AnotherSourceDto { /* add properties */ };
        var destination = mapper.CustomMap(source, anotherSource);
    }
