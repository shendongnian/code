    static class GlobalState
    {
        public static IList<object> GlobalStuff = new List<object>();
    }
    class Hacker
    {
        public Hacker()
        {
            GlobalState.GlobalStuff.Add(this);
        }
        public override string ToString()
        {
            return "hacker!!";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Hacker();
            Console.WriteLine(GlobalState.GlobalStuff[0].ToString());
        }
    }
