    public class First
    {
        public string GetName()
        {
            return "First";
        }
    }
    public class Second : First
    {
        public new string GetName()
        {
            return "Second";
        }
    }
    public static class Program
    {
      
        public static void Main(string[] args)
        {
            Second second = new Second();
            Console.WriteLine(second.GetName());
            // Prints "Second"
            First first = second;
            Console.WriteLine(first.GetName());
            // Prints "First"
            Console.ReadKey();
        }
    }
