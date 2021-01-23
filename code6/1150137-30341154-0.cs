            Console.Title = "Quadrado Mágico";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Random ran = new Random();
            Console.Clear();
            int[ , ] quadrado = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            // ... Loop using the GetUpperBounds.
            for (int fila = 0; fila <= quadrado.GetUpperBound(0); fila++)
            {
                for (int coluna = 0; coluna <= quadrado.GetUpperBound(1); coluna++)
                {
                    // Display the element at these indexes.
                    Console.WriteLine(quadrado[fila, coluna]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
