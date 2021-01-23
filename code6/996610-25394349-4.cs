    class Dealer
    {
        private List<string> shuffledDeck= new List<string>();
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
            shuffledDeck= deck;
        }
        private void deal()
        {
            while (shuffledDeck.Count > 0)
            {
                foreach (var player in allplayers)
                {
                    player.Add(shuffledDeck[shuffledDeck.Length - 1];
                    shuffledDeck.RemoveAt(shuffledDeck.Length - 1];
                    if (shuffledDeck.Length == 0)
                        break;
                }
            }
        }
    }
