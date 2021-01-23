    [XmlRoot(ElementName = "personalinfo")]
    public class Personalinfo
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "firstname")]
        public string Firstname { get; set; }
        [XmlElement(ElementName = "sex")]
        public string Sex { get; set; }
        [XmlElement(ElementName = "birthday")]
        public string Birthday { get; set; }
        [XmlElement(ElementName = "group")]
        public string Group { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
    }
    [XmlRoot(ElementName = "items")]
    public class Items
    {
        public Items()
        {
            this.Item = new List<string>();
        }
        [XmlElement(ElementName = "item")]
        public List<string> Item { get; set; }
    }
    [XmlRoot(ElementName = "candidate")]
    public class Candidate
    {
        public Candidate()
        {
            this.Items = new Items();
        }
        [XmlElement(ElementName = "personalinfo")]
        public Personalinfo Personalinfo { get; set; }
        [XmlElement(ElementName = "items")]
        public Items Items { get; set; }
    }
    [XmlRoot(ElementName = "candidates")]
    public class Candidates
    {
        public Candidates()
        {
            this.Candidate = new List<Candidate>();
        }
        [XmlElement(ElementName = "candidate")]
        public List<Candidate> Candidate { get; set; }
    }
    [XmlRoot(ElementName = "candidatelist")]
    public class Candidatelist
    {
        public Candidatelist()
        {
            this.Candidates = new Candidates();
        }
        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }
        [XmlElement(ElementName = "candidates")]
        public Candidates Candidates { get; set; }
    }
