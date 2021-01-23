        public class Game {
            public int Id { get; set; }
            public virtual ICollection<GamePlayer> Players { get; set; }
        }
        public enum Color { White = 1, Black = 2}
        public class GamePlayer {
            public int Id { get; set; }
            public virtual Game GamePlayed { get; set; }
            public Color PlayedAs { get; set; }
            public virtual Player Player { get; set; }
        }
        public class Player {
            public virtual ICollection<GamePlayer> Games { get; set; }
        }
