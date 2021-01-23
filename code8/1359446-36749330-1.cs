    public class Main
    {
       public static int main(string [] args) //if you're using the console
       {
          GameBoard gameBoard = new GameBoard(32, 32); // gameboard is size 32x32
          gameBoard.SetGameBoardValues();
          gameBoard.Tiles[0, 0] = 1; //You can access values this way.
       }
    }
