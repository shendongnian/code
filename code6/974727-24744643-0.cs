    public abstract class GameState
    {
        public int TimeOutTime { get; set; }
        public void CheckDoStuff()
        {
            if (elapsedTime > gameState.TimeOutTime) DoStuff();
        }
        protected abstract void DoStuff();
    }
    public WaitState : GameState
    {
        protected override DoStuff()
        {
            // Do stuff (wait)
        }
    }
    public PlayState : GameState
    {
        protected override DoStuff()
        {
            // Do other stuff (play)
        }
    }
