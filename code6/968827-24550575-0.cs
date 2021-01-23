    public static class MappingExtensions
    {
        static MappingExtensions()
        {
            Mapper.CreateMap<CustomAlerts, Domain.Models.CustomAlerts>();
            Mapper.CreateMap<Domain.Models.CustomAlerts, CustomAlerts>();
            //add mappings for each set of objects here. 
            //Remember to map both ways(from x to y and from y to x)
        }
        
        //map single objects
        public static TDestination Map<TSource, TDestination>(TSource item)
        {
            return Mapper.Map<TSource, TDestination>(item);
        }
        //map collections
        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> item)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(item);
        }
    }
