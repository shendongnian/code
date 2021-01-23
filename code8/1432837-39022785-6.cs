    public class Wrapper<T>
        where T : class
    {
        public Wrapper(T wrappee)
        {
            Class = wrappee;
        }
        public T Class { get; } // C# 6.0 Syntax, otherwise add "private set;"
    } 
