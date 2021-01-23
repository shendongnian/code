    [XmlRoot("Games")]
    public class GameRepository : Repository<GameRepository>
    {
        [XmlElement("Game")]
        public override sealed List<Game> Items { get; set; }
    
        private GameRepository()
        {
            Items = new List<Game>();
        }
    }
