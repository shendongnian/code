     public static class MyLinqExtensions
    {
        public static IQueryable<AccessTypeDto> GetPage(this IQueryable<AccessType> source, int pageIndex, int pageSize)
        {
            return source.Select(x => new AccessTypeDto()
            {
                AccessTypeID = x.AccessTypeID,
                AccessTypeName = x.AccessTypeName
            }).OrderBy(x => x.AccessTypeID).Skip(pageIndex*pageSize).Take(pageSize);
        }
    } 
