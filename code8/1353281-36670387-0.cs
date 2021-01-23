    public class EntitiesProjector : IEntitiesProjector
    {
        private readonly IMapperConfiguration _mapperConfig;
        public EntitiesProject(IMapperConfiguration mapperConfig)
        {
            _mapperConfig = mapperConfig;
        }
        public IQueryable<T> SelectTo<T>(IQueryable source)
        {
            return source.ProjectTo<T>(_mapperConfig);
        }
    }
