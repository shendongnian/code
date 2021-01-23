    public interface IBar<T> where T : new()
    {
        T DoBarStuff<T>();
    }
    public class Bar<T> : IBar<T> where T : new()
    {
        public T DoBarStuff()
        {
            // do bar stuff
            return new T(); 
        }
    }
