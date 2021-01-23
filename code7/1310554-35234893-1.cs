    public interface IMapper
    {
        T Map<T>(object objectToMap);
    }
    public class AutoMapperAdapter : IMapper
    {
        public T Map<T>(object objectToMap)
        {
            //Mapper.Map is a static method of the library!
            return Mapper.Map<T>(objectToMap);
        }
    }
