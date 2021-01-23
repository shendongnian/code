    public abstract class Command
    {
        [XmlAttribute("content")]
        public string Content { get; set; }
        public abstract void Process(List<string> output);
    }
