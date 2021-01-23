    abstract class a
    {
        public  abstract string look();
        public static string lookStatic()
        {
            return "look";
        }
    }
    class b : a
    {
        public override string look()
        {
            return "look member";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(b.lookStatic());
            var test = new b();
            Console.WriteLine(test.look());
            var c = (a) test;
            Console.WriteLine(c.look());
            Console.ReadLine();
        }
    }
