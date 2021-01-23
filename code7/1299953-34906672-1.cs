    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            machine();
        }
        private static void machine()
        {
            if (rand.Next(1, 9) == 1)
                Console.WriteLine("We did it!");
            else
                machine();
        }
    }
