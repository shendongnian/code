    [XmlRoot("Phrases")]    
    public class Phrases : List<Phrase>
    {
            
    }
    
    public class Phrase
    {
        [XmlAttribute]
        public int Role { get; set; }
    }
