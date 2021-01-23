        private static void Main()
        {
            CsGoIntegration();
        }
    
        private static void CsGoIntegration()
        {
            var gsl = new GameStateListener(3000);
            gsl.NewGameState += OnNewGameState;
            if (!gsl.Start())
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Listening...");
        }
    
        private static void OnNewGameState(GameState gameState)
        {
            SaveMatchsData(gameState);
        }
    
        private static int? _totalKillScore;
        private static string _lastMapName;
        private static int? _lastKillScore;
    
        private static void SaveMatchsData(GameState gameState)
        {
            const string undefinedString = "Undefined";
    
            //  If the SaveMatchsData is running and the CSGO server is offline
            if (gameState.Map.Name == undefinedString && string.IsNullOrEmpty(_lastMapName))
                return;
    
            //  When the match is not started, the Round is -1
            if (gameState.Map.Name != undefinedString && gameState.Map.Round > -1)
            {
                if (string.IsNullOrEmpty(_lastMapName))
                {
                    UpdateData(gameState, true);
                }
                else
                {
                    //  Same map
                    if (_lastMapName == gameState.Map.Name)
                    {
                        //  Check if the Score Changes
                        if (_lastKillScore == gameState.Player.MatchStats.Kills) return;
                        UpdateData(gameState);
                    }
                    //  The Map Changes
                    else
                    {
                        UpdateData(gameState, true);
                    }
                }
    
            }
        }
    
        private static void UpdateData(GameState gameState, bool updateMap = false)
        {
            if (updateMap)
                _lastMapName = gameState.Map.Name;
            _lastKillScore = gameState.Player.MatchStats.Kills;
            _totalKillScore += gameState.Player.MatchStats.Kills;
        }
