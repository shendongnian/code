    public interface IBase
    {
      string Caption { get; }
    }
    public class Base<T>: IBase
    {
      public string Caption { get { return typeof(T).Name; } }
    }
