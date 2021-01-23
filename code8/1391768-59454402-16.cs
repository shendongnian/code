    public class Service<I, T> : IService<I>
    {
        public Type Type()
        {
            return typeof(T);
        }
    }
