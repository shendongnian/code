    public abstract class Base<T>
    {
      public T Context { get; protected set; }
    }
    public class Derived : Base<DerivedContext>
    {
      ...
    }
