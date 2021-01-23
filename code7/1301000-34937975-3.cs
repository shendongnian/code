        static void Main(string[] args)
        {
            CsGoIntegration();
        }
    
        private static void CsGoIntegration()
        {
            var gsl = new GameStateListener(3000);
            gsl.NewGameState += new NewGameStateHandler(OnNewGameState);
            if (!gsl.Start())
            {
                Environment.Exit(0);
            }
            System.Console.WriteLine("Listening...");
        }
        private static void OnNewGameState(GameState gs)
        {
            System.Console.WriteLine("Map: {0}", gs.Map.Name);
            System.Console.WriteLine("Player Name: {0}", gs.Player.Name);
            System.Console.WriteLine("Player Kills: {0}", gs.Player.MatchStats.Kills);
        }
