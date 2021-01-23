        for (int y = 0; y < 8; y++){
            for (int x = 0; x < 8; x++){
                if (board[x, y] == SquareState.gotCheese)
                    Console.Write("C");
                else
                    Console.Write("*");
             }
             Console.WriteLine();
        }
