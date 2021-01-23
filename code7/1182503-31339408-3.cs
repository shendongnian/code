    public class Timed<T>
    {
        public readonly TimeSpan Duration;
        public readonly T Result;
        // making constructor private to force static factories usage
        private Timed(T result, TimeSpan duration) 
        {
            Result = result;
            Duration = duration;
        }
    
        // static factory method instead of constructor, for generic parameter 
        // type inference 
        public static Timed<T> Create(T result, TimeSpan duration) 
        {
            return new Timed<T>(result, duration);
        }
    }
