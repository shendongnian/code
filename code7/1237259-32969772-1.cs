    abstract class GameState
    {
        private bool visible;
        public abstract void Update();
        public void Draw() 
        { 
        }
    }
    class GameStateMenu : GameState
    {
        public override void Update()
        {
        }
    }
