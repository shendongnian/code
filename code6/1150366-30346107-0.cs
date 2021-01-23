        try{
            bool ReRunGame = false; <<<<
            do
            {
                Console.Clear();
                G.StartingGameBoard();
                while(true)
                {
                    G.BoardDisplay();
                    G.Playing(G.ChecksException());
                    G.BoardDisplay();
                    G.IfWinning();
                    G.IsTie();
                    G.CurrentPlayer = G.GetTheNextPlayer(G.CurrentPlayer);
                }   
                Console.WriteLine("Play another game?");
                ConsoleKeyInfo ck = Console.ReadKey();
                ReRunGame = (ck.Key == ConsoleKey.Y);
            }while(ReRunGame);  <<<<<
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
