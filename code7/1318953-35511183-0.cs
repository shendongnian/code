    public class AddPlayersToGame
    {
        public string GameTitle { set; get; }
        public int GameID { set; get; }
        public int[] PlayerIDs { get; set; }
        public MultiSelectList Players { get; set; }
    }
