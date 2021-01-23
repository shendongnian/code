    public class Program
    {
        public static void Main()
        {
            Game myGame = new Game();
            myGame.PlayGame();
        }
    }
    public class Game
    {
        public Player myPlayer = new Player();
        public void PlayGame()
        {
            // place your loop / logic here to request input from the user and update your game state
        }
        public void WritePLayerStats()
        {
            string[] lines = { myPlayer.stat1, myPlayer.stat2 };
            File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
            Process.Start(@"C:\Users\Public\TestFolder\WriteLines.txt");
        }
    }
    public class Player
    {
        public int health = 20;
        public string stat1 = "";
        public string stat2 = "";
    }
