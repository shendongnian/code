    public class Being
    {
        // [XmlAttribute]
        public string Data { get; set; }
        // Here add the following attributes to the property
        [XmlArray("Humans")]
        [XmlArrayItem("Human")]
        public List<Person> Humans { get; set; }
        public bool ShouldSerializeHumans()
        {
            this.Humans = this.Humans.Where(x => !x.Deceased).ToList();
            return true;
        }
    }
