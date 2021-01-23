        static void Main(string[] args)
        {
            Console.Title = "Quadrado Mágico";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Random ran = new Random();
            Console.Clear();
            const int f = 3;
            const int c = 3;
            int[,] quadrado = new int[f, c]
            {
                {0, 0, 0}, {0, 0, 0}, {0, 0, 0}
            };
            for (int fila = 0; fila < f; fila++)
            {
                for (int coluna = 0; coluna < c; coluna++)
                {
                    Console.WriteLine(quadrado[fila, coluna] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
