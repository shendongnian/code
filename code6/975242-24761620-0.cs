    public class GameData
    {
        public int[,] mat { get; set; }
        public int dim { get; set; }
        public int goal { get; set; }
        public Game game { get; set; }
    
        public GameData()
        {
            game = new Game();
        }
    }
    
    public class Game
    {
        private Mover m;
    
        public Game()
        {
            dim = 4;
            goal = 16;
            mat = new int[dim, dim];
            m = new Mover();
        }
        /*Methods*/
    }
    
    public class Mover
    {
        /*Methods*/
    }
