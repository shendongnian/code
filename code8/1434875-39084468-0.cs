    internal class Program
    {
        enum Planet { Sun = 0, Moon = 1 }
        private static void Main(string[] args)
        {
            var x = (Planet) ((object) (byte)1);
            Console.WriteLine(x);
        }
    }
