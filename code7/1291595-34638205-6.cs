    public interface IGenericContainer
    {
        dynamic Data { get; }
    }
    public class GenericContainer<T> : IGenericContainer
    {
        T _Data { get; set; }
        public GenericContainer(T data)
        {
            _Data = data;
        }
        dynamic IGenericContainer.Data
        {
            get { return _Data; }
        }
    }
    public class GenericContainer
    {
        public static GenericContainer<T> Create<T>(T data)
        {
            return new GenericContainer<T>(data);
        }
    }
