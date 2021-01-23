    void Main()
    {
      Test test = new Test();
      if (test = null)
      {
        Console.WriteLine("!");
      }
    }
    public class Test
    {
      public static implicit operator bool(Test x)
      {
        return true;
      }
    }
