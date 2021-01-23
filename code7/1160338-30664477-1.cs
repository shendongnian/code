    public class WeirdSelect
    {
      public int Select<T>(Func<WeirdSelect, T> ignored)
      {
        Console.WriteLine("Select‎ Was Called");
        return 2;
      }
      public int Select<T>(Expression<Func<WeirdSelect, T>> ignored)
      {
        Console.WriteLine("Select‎ Was Called on expression");
        return 1;
      }
    }
    void Main()
    {
      int result = from whatever in new WeirdSelect() select whatever;
    }
