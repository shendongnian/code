    static void Main(string[] args)
        {
            Console.WriteLine("Mata in Start");
            int startNummer = int.Parse(Console.ReadLine());
            Console.WriteLine("Mata in Stop");
            int stopNummer = int.Parse(Console.ReadLine());
            Console.WriteLine("Mata in Steg");
            int stegNummer = int.Parse(Console.ReadLine());
            for (int n = startNummer; n >= stopNummer; n += stegNummer)
            {
                Console.WriteLine();
            }
        }
