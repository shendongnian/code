    class StateManager
    {
        List<GameState> _states = new List<GameState>();
        List<GameState> _statesCopy = new List<GameState>();
        public Game Game                { get; private set; }
        public SpriteBatch SpriteBatch  { get; private set; }
        public StateManager(Game game, SpriteBatch sb)
        {
            Game = game;
            SpriteBatch = sb;
        }
        
        public void AddState(GameState state)
        {
            _states.Add(state);
        }
        public void RemoveState(GameState state)
        {
            _states.Remove(state);
        }
        public void Update(GameTime gameTime)
        {
            _statesCopy.Clear();
            foreach (GameState state in _states)
                if (state.RequireUpdate)
                    _statesCopy.Add(state);
            foreach (GameState state in _statesCopy)
                if (state.RequireUpdate)
                    state.Update(gameTime);
        }
        public void Draw()
        {
            foreach (GameState state in _states)
                state.Draw();
        }
    }
}
