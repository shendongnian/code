    class Game
    {
        public delegate void GameStartedHandler(Game sender, EventArgs eventArgs);
        public delegate void GameEventHandler(Game sender, GameData eventData);
        public event GameStartedHandler GameStarted = delegate { };
        public event GameEventHandler GameEvent = delegate { };
        public void Start()
        {
            GameStarted(this, EventArgs.Empty);
        }
        public void SaveDataFeedback()
        {
            var dataobject = new GameData();
            // filling data object
            GameEvent(this, dataobject);
        }
    }
