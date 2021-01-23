    public static class MyConsole
    {
        public static int ReadInt()
        {
            int k = 0;
            string val = Console.ReadLine();
            if (Int32.TryParse(val, out k))
                Console.WriteLine("You have typed a valid integer: " + k);
            else
                Console.WriteLine("This: " + val + " is not a valid integer");
            return k;
        }
        public static double ReadDouble()
        {
            double k = 0;
            string val = Console.ReadLine();
            if (Double.TryParse(val, out k))
                Console.WriteLine("You have typed a valid double: " + k);
            else
                Console.WriteLine("This: " + val + " is not a valid double");
            return k;
        }
        public static bool ReadBool()
        {
            bool k = false;
            string val = Console.ReadLine();
            if (Boolean.TryParse(val, out k))
                Console.WriteLine("You have typed a valid bool: " + k);
            else
                Console.WriteLine("This: " + val + " is not a valid bool");
            return k;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int s = MyConsole.ReadInt();
        }
    }
