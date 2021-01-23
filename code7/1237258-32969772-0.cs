    abstract class GameState
    {
        private bool visible;
        public abstract void Update();
        public abstract void Draw();
    }
    class GameStateMenu : GameState
    {
        public override void Update()
        {
        }
        public override void Draw()
        {
        }
    }
