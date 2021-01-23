    public interface IBar
    {
        T DoBarStuff<T>() where T : new();
    }
    public class Bar : IBar
    {
        public T DoBarStuff<T>() where T : new()
        {
            // do bar stuff
            return new T(); 
        }
    }
