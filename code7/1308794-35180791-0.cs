    public class Player
    {
        public int Chips { get; set }
        public int Type { get; set }
        public int Power { get; set }
        public bool BotTurn { get; set }
        public bool BotFoldTurn { get; set }
        public AnchorStyles PlayerCardsAnchor { get; }
    
        public Player(AnchorStyles playerCardsAnchor, more parameters for properties)
        {
            PlayerCardsAnchor = playerCardsAnchor;
            // set other properties here
        }
    }
    MainPoker()
    {
        var player = new Player(AnchorStyles.Bottom, more parameters);
        var bot1 = new Player(AnchorStyles.Left, more parameters);
        //more bots
    }
