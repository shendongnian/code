    public abstract class Fallible<T> {
    }
     
    public class Success<T> : Fallible<T> {
      public T Value { get; set; }
    }
     
    public class Failure<T> : Fallible<T> {
      public Exception Exception { get; set; }
    }
