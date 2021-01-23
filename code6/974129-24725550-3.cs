    public class GameEngine
    {
        private readonly GameOptions _options;
        public GameEngine()
        {
            _options = new GameOptions();    
        }
    
        public void ShowSetupScreen()
        {
            //If the setup screen modifies the values inside the _gameOptions variable 
            // by passing the variable in it removes the need for "Global variables"
            using(var setupScreen = new SetupScreen(_gameOptions);
            {
                setupScreen.Show();
            }
        }
    
        public void Enemy CreateEnemy()
        {
            //Creates a new enemy and passes the options in so it can read the settings
            // like the difficulty level.
            return new Enemy(_gameOptions);
        }
    
        //And so on.
