    class Game
    {
        private List<Level> levels;
        private Player player;
    
        public Game()
        {
            player = new Player();
            Levels.Add(ref player);
        }
        // uncomment this method if you need it
        //public Player CreatePlayer()
        //{
        //    return new Player();
        //}
        private class Player : AbstractPlayer
        {
            public Player()
            {
            }            
        }
    }
