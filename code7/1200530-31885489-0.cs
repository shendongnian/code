    class Program
    {
        static void Main(string[] args)
        {
            var s = new Sprite();
            s.Action = dostuff;
            // outputs Hello
            s.Action.Invoke();
            Console.ReadLine();
        }
        public static void dostuff() { Console.WriteLine("Hello"); }
        public class Sprite
        {
            public Action Action { get; set; }
        }
    }
