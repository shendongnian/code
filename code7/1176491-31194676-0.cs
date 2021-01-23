    public class GameTypeManager
    {
        public static IGameType RunningGame;
    
        public void Setup (int selectedGameType)
        {
            RunningGame = GetGameType(selectedGameType);
            EventManager.Killed += RunningGame.CheckGameOver;
        }
    
        public void TearDown ()
        {
            EventManager.Killed -= RunningGame.CheckGameOver;
            RunningGame = null;
        }
    
        public IGameType GetGameType(int gameType)
        {
            IGameType currentGameType = null;
            switch (gameType)
            {
                case 0 :
                    currentGameType = new GameType0();
                    break;
                // Additional cases...
            }
            return currentGameType;
        }
    }
    public interface IGameType
    {
        void CheckGameOver(PlayerState deadPlayer);
    }
