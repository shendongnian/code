    for (int row = 0; row < 5; row++)
        {
            for (int column = 0; column + row < 4; column++)
            {
                Console.Write(" ");
            }
            for (int column = 0; column <= row * 2; column++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
