    class Level
    {
        private List<GameObject> gameObjects;
    
        public Level(ref Player player)
        {
            gameObjects.Add(player);
            player.Level = this;
        }
    
        public void DoSomething() {}
    }
