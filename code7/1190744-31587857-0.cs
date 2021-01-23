    namespace Overbox
    {
        class UpdateHandler
        {
            public enum GameState 
            { 
                MainMenu, 
                Options, 
                Playing, 
                GameOver, 
                Exiting 
            };
            
            public GameState currentGameState;
            
            public UpdateHandler()
            {
                this.currentGameState = GameState.MainMenu;
            }
            public void Update(GameTime gameTime)
            {
    
            }
        }
    }
