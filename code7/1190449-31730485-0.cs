    public static class DTOResolver
    {
        public static void RegisterSetForDTO<TSet, TDTO>()
            where TDTO : class
            where TSet : class
        {
            DTOResolver<TDTO>.SetType = typeof(TSet);
            DTOResolver<TDTO>.SetMapper = new DTOResolver<TDTO>.Mapper<TSet>();
        }
    }
    public static class DTOResolver<TDTO> where TDTO : class
    {
        public abstract class Mapper
        {
            public abstract TDTO Map(Object entity);
        }
        public class Mapper<TSet> : Mapper
        {
            public override TDTO Map(Object entity)
            {
                return AutoMapper.Mapper.Map<TSet, TDTO>((TSet) entity);
            }
        }
        public  static  Type    SetType { get; set; }
        public  static  Mapper  SetMapper { get; set; }
    }
