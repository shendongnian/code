    public class Program
    {
        public static void Main(string[] args)
        {
            Game GC = new Game();
            var players = GC.GetNumberPlayers();
            var scores = GC.SetInitialScores();
    		
    		Console.WriteLine("You entered {0} players!", players);
    		
    		Console.WriteLine("Printing scores");
    		foreach (int val in scores)
    		{
    			Console.WriteLine(val);
    		}
    		
        }               
    }
    
    public class Game
    {
        private int players = 0;
        private int[] scores;
        private string[] playerNames;
    
        public int Players
        {
            get { return players; }
            set { players = value; ; }
        }
    
        public int[] Scores
        {
            get { return scores; }
            set { scores = value; }
        }
    
        public int GetNumberPlayers()
        {
            string playersString;
            Console.WriteLine("Enter number of players");
            playersString = Console.ReadLine();
            Int32.TryParse(playersString, out players);
            return players;
        }
    
        public int[] SetInitialScores()
        {
    		scores = new int[players];
    		
            for (int i = 0; i < players; i++ )
            {
                scores[i] = 0;
            }
    		
            return scores;
        }
    }
