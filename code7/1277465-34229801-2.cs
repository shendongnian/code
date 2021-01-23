    public class Test
    {
      public static bool operator true(Test x)
      {
        return true;
      }
      public static bool operator false(Test x)
      {
        return false;
      }
    }
    void Main()
    {
      Test test = new test();
      if (test = null)
      {
        Console.WriteLine("!");
      }
    }
