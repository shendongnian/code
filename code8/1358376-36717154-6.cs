        int playerX = 0; //horizontal coordinate
        int playerY = 0; //vertical coordinate
        ConsoleKey key = ConsoleKey.Separator; //filled with meanless value by default
        do
        {
            switch (key)
            {
                case ConsoleKey.W:
                    if (playerY > 0) //check that player will't leave field
                        playerY--;   //change player position
                    break;
                case ConsoleKey.D:
                    if (playerX < values.GetLength(1) - 1)
                        playerX++;
                    break;
                case ConsoleKey.S:
                    if (playerY < values.GetLength(0) - 1)
                        playerY++;
                    break;
                case ConsoleKey.A:
                    if (playerX > 0)
                        playerX--;
                    break;
            }
            Console.Clear(); //clear console to redraw field
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int k = 0; k < values.GetLength(1); k++)
                {
                    if (i == playerY && k == playerX) //check if player in cell [i,k]
                        Console.Write("Player\t"); //draw player
                    else
                        Console.Write(values[i, k] + "\t"); //draw place
                }
                Console.WriteLine();
            }
            key = Console.ReadKey(true).Key; //read new key
        }
        while (key != ConsoleKey.X); //exit condition
