    public class AutoMapperMappings
    {
        public static void Configure(IWindsorContainer container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LatestUpdateModel, LatestUpdate>();
                ...
            });
            var mapper = config.CreateMapper();
            // register your mapper here.
            container.Register(Component.For<IMapper>().Instance(mapper));
        }
    }
