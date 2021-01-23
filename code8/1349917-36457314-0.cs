    public class Base
    {
  
    }
  
    public class Derived : Base
    {
  
    }
  
    public interface IWrapper<out T> where T : Base
    {
  
    }
  
    public class Wrapper<T> : IWrapper<T> where T : Base
    {
  
    }
  
    public static class Methods
    {
      public static void Test()
      {
        var obj = new List<IWrapper<Base>>();
        obj.Add(new Wrapper<Derived>());
      }
    }
