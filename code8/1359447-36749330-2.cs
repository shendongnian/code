        public class GameBoard
        {
            private int _height;
            private int _width;
            public Tile[,] Tiles; // Tile array is now a field
            
            public GameBoard(int height, int width)
            {
               _height = height;
               _width = width;
               Tiles = new Tile[width, height]; 
            }
        // I'm fairly certain the default value for c# of an integer is 0
        // so you may not need the following.
            public void SetGameBoardValues()
            {
                Random rand = new Random(); //only add if you want to randomly generate the board
                for (int x = 0; x < width; x++)//arrays start at 0
                {
                    for (int y = 0; y < height; y++)//arrays start at 0
                   {
                       Tiles[x, y] = 0;
                       // If you'd like to randomly assign the value you can do:
                       Tile[x,y] = rand.Next(0,2)
                   }
                }
            }
        }
