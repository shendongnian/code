    class Program
    {
        const string CFd = "...\\...\\Duomenys.txt";
    
        static void Main(string[] args)
        {
           int ki, kj;
            int[,] Grafas;
            using (StreamReader reader = new StreamReader(CFd))
            {
                string line;
                string[] parts;
                ki = int.Parse(reader.ReadLine()); //read first line
                kj = int.Parse(reader.ReadLine()); //read second line
                Grafas = new int[ki, kj]; //define array size
                for (int i = 0; i < ki; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < kj; j++)
                    {
                        Grafas[i, j] = int.Parse(parts[j]); //no more exception!
                        Console.Write("{0} ", Grafas[i, j]); //Output here, so no need for second loop.
                    }
                    Console.WriteLine();
                }
            }
           
            Console.ReadLine();
        }
    }
