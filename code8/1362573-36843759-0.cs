    public MapperConfiguration Config { get; set; }
    [SetUp]
    public void SetUp()
    {
        var innerConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Namespace10.Inner, Namespace20.Inner>();
        });
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Namespace10.Outer, Namespace20.Outer>()
            .AfterMap((src, dest) =>
            {
                dest.Inner = innerConfig.CreateMapper().Map<Namespace20.Inner>(src.Inner as Namespace10.Inner);
            });
        });
        Config = config;
    }
    [Test]
    public void Map()
    {
        Namespace10.Outer source = new Namespace10.Outer();
        source.Inner = new Namespace10.Inner();
        var dest = Config.CreateMapper().Map<Namespace10.Outer, Namespace20.Outer>(source);
        Assert.AreEqual(typeof(Namespace20.Inner).FullName, dest.Inner.GetType().FullName);
    }
