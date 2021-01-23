    public class Person
    {
        public string Name { get; set; }
        
        [BsonIgnoreIfNull]
        public List<string> Children { get; set; }
    }
