        enum CardValue
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4
        }
        
        static void Main(string[] args)
        {
            int myInt = (int)CardValue.One;
            Console.WriteLine("output should be 1: " + myInt);
            int mySum = (int)CardValue.One + (int)CardValue.Three;
            Console.WriteLine("output should be 4: " + mySum);
            Console.ReadKey();
        }
