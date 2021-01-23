    public class ParseFieldName: Attribute
    {
        public string Name { get; set; }
        public ParseFieldName(string name)
        {
            this.Name = name;
        }
    }
