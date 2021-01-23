    class Dealer
    {
        private List<string> suffeledDeck = new List<string>();
        private static List<string> playerOne = new List<string>();
        private static List<string> playerTwo = new List<string>();
        private static List<string> playerThree = new List<string>();
        private static List<string> playerFour = new List<string>();
        private static List<string> playerFive = new List<string>();
        private static List<string> playerSix = new List<string>();
        private static List<List<string>> allplayers = new List<List<string>> { playerOne, playerTwo,playerThree,playerFour,playerFive,playerSix };
    
        private int counter = 0;
        private int playerCount = allplayers.Count;
        public Dealer(string[] deck)
        { 
            suffeledDeck = deck;
        }
        private void deal()
        {
            while (suffeledDeck.Count > 0)
            {
                foreach (var player in allplayers)
                {
                    player.Add(suffeledDeck[suffeledDeck.Length - 1];
                    suffeledDeck.RemoveAt(suffeledDeck.Lenght - 1];
                    if (suffeledDeck.Length == 0)
                        break;
                }
            }
        }
    }
