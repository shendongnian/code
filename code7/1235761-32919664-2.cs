    public class Book
    {
        public string Title { get; set; }
        public ISBN ISBN { get; set; }
    }
    public class ISBN
    {
        [XmlText]
        public string value { get; set; }
        [XmlAttribute]
        public string friendlyName { get; set; }
    }
