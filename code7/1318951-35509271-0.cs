    public class AddPlayersToGame
    {
        public string GameTitle { set; get; }
        public int GameID { set; get; }
        public int PlayerID { get; set; }
        public int[] PlayerIds { set; get; }
        public List<SelectListItem> Players { set; get; }
    }
