    public interface IBar<T> where T : class, new()
    {
        T DoBarStuff<T>();
    }
    public class Bar<T> : IBar<T> where T : class, new()
    {
        public T DoBarStuff()
        {
            // do bar stuff
            return new T(); 
        }
    }
