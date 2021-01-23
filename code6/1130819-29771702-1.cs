    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        public string Username { get; set; }
        public virtual ICollection<OpenedGame> OpenedGames { get; set; }
    }
    public class Game
    {
        public int GameId { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual ICollection<OpenedGame> OpenedGames { get; set; }
    }
    public class OpenedGame
    {
        public int OpenedGameId { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int Location { get; set; }
    }
