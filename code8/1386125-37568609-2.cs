        public static void Main()
		{
			ExtensionMethods em = new ExtensionMethods();
			em.PlayerWon();
		}
	
        public void PlayerWon()
        {
            
                NewGame();
            
        }
       
        public void NewGame()
        {
			Console.Write("Starting New Game");
        }
	}
