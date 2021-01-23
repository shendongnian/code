    public class WeirdSelect
    {
      public int Select<T>(Func<WeirdSelect, T> ignored)
      {
        Console.WriteLine("Select‎ Was Called");
        return 2;
      }
    }
    void Main()
    {
      int result = from whatever in new WeirdSelect() select whatever;
    }
