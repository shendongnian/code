    public static class MapperHelper
    {
        public static TDest ToViewModel<TSource, TDest>(this TSource cust)
        {
           return AutoMapper.Mapper.Map<TSource, TDest>(cust);
        }
    }
