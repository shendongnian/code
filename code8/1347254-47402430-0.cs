    public class CatResponse
    {
        public string index { get; set; }
        ...
        [DeserializeAs(Name = "docs.count")]
        public string docscount { get; set; }
    }
