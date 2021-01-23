    [XmlRoot("AttackPattern")]
    public class TeamContainer
    {
        public AttackPatternLeft AttackPatternLeft { get; set; }
    }
    public class AttackPatternLeft
    {
        [XmlArray("Pattern")]
        [XmlArrayItem("Player")]
        public List<Player> Team { get; set; }
    }
    public class Player
    {
        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }
        [XmlAttribute]
        public string Id { get; set; }
    }
