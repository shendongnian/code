    public interface IBar
    {
        T DoBarStuff<T>() where T : class, new();
    }
    public class Bar : IBar
    {
        public T DoBarStuff<T>() where T : class, new()
        {
            // do bar stuff
            return new T(); 
        }
    }
