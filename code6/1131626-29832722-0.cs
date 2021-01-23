    public static class MapperHelper
    {
        public static TDest MapTo<TDest>(this object src)
        {
            return (TDest)AutoMapper.Mapper.Map(cust, src.GetType(), typeof(TDest));
        }
    }
