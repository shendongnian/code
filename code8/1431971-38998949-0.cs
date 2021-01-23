    public interface IBar<T> where T : IFoo, new()
    {
        T DoBarStuff();
    }
    public class Bar<T> : IBar<T>
    {
        public T DoBarStuff() where T : IFoo, new()
        {
            // do bar stuff
            return new T(); 
        }
    }
