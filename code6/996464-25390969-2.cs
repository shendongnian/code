    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 44;
            Console.WindowHeight = 33;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            string template = "|{0,-5}|{1,-11}|{2,-5}|{3,-5}|{4,-5}|{5,-5}|";
            Console.WriteLine(template, "s1", "s2", "out1", "out2", "out3", "out4");
            Console.WriteLine(template, new String('-', 5), new String('-', 11), new String('-', 5), new String('-', 5), new String('-', 5), new String('-', 5));
            // repeat experiment with different master RNGs
            for (int iMaster = 0; iMaster < 30; ++iMaster)
            {
                int s1 = iMaster + OFFSET;
                // create master RNG
                var rngMaster = new Random(s1);
                // obtain seed from master RNG
                var s2 = rngMaster.Next();
                // create main RNG from seed
                var rngMain = new Random(s2);
                var out1 = rngMain.Next(LIMIT);
                var out2 = rngMain.Next(LIMIT);
                var out3 = rngMain.Next(LIMIT);
                var out4 = rngMain.Next(LIMIT);
                Console.WriteLine(template, s1, s2, out1, out2, out3, out4);
            }
            Console.ReadLine();
        }
        const int OFFSET = 0;
        const int LIMIT = 200;
    }
