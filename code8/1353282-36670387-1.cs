    public class EntitiesProjector : IEntitiesProjector
    {
        private readonly IConfigurationProvider _mapperConfig;
        public EntitiesProjector(IMapperConfiguration mapperConfig)
        {
            _mapperConfig = (IConfigurationProvider)mapperConfig;
        }
        public IQueryable<T> SelectTo<T>(IQueryable source)
        {
            return source.ProjectTo<T>(_mapperConfig);
        }
    }
