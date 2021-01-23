    public class Game
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Dlc> Dlcs { get; set; } 
    }
    public class Dlc
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public virtual Game game { get; set; } 
    }
