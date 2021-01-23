    public abstract class Superbase
    {
      public abstract string Caption { get; }
    }
    public class Base<T>: Superbase
    {
      public override string Caption { get { return typeof(T).Name; } }
    }
