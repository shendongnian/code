    using AutoMapper.QueryableExtensions;
    public static IQueryable<MyTableDTO> ToDto(this IQueryable<MyTable> query)
    {
        return query.ProjectTo<MyTableDTO>();
    }
