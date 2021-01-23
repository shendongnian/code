    for (int x = 0; x < 8; x = x + 1){
                for (int y = 0; y < 8; y = y + 1){
                    if (board[x, y] == SquareState.gotCheese)
                        Console.Write("C");
                    else
                        Console.Write("*");
                Console.WriteLine("");
                }
    }
