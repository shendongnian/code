     // Has the player won (5 horizontal ticks)?
     public bool HasWinner(Label[,] board, Colour player)
     {
         for (int y = 0; y < 19; y++)
         {
            if (RowHasLine(y, board, player)
               return true;
         }
         return false;
     }
     // Returns true if player has a winner in row y
     private bool RowHasLine(int y, Label[,] board, Colour player)
     {
         for (int x = 0; x < 19; x++)
         {
             if (Ticked(x + 0, y, board, player) &&
                 Ticked(x + 1, y, board, player) &&
                 Ticked(x + 2, y, board, player) &&
                 Ticked(x + 3, y, board, player) &&
                 Ticked(x + 4, y, board, player))
             {
                 return true;
             }
         }
         return false;
     }
     // Has the player ticked this box?
     private bool Ticked(int x, int y, Label[,] board, Colour player)
     {
         if (x >= 19 || y >= 19)
             return false;
 
         return (board[x][y].BackgroundColor == player);
     }
