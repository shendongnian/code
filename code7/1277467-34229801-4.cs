    public class Test
    {
      public static bool operator == (Test x, Test y)
      {
        return ReferenceEquals(x, null);
      }
      public static bool operator !=(Test x, Test y)
      {
        return !(x == y);
      }
    }
    void Main()
    {
      Test test = new Test();
      if (test == null)
      {
        Console.WriteLine("This won't print.");
      }
      if (null == test)
      {
        Console.WriteLine("This will print.");
      }
    }
