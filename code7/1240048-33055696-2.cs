    class Game
    {
        private List<Level> levels;
        private Player player;
    
        public Game()
        {
            player = new Player();
            Levels.Add(player);
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
    class Level
    {
        private List<GameObject> gameObjects;
    
        public Level(Player player)
        {
            gameObjects.Add(player);
            player.Level = this;
        }
    
        public void DoSomething() {}
    }
