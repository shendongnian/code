            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column + row < 4; column++)
                {
                    Console.Write(" ");
                }
                for (int column = 0; column + row >= 0; column++)
                {
                    if (column == (row * 2) + 1)
                        break;
                    Console.Write("*");
                }
                Console.WriteLine();
            }
