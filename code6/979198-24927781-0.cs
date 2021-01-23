    public class DocumentItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }
        public SubItem[] Values { get; set; }
    }
    public class SubItem
    {
        public String Name { get; set; }
        public Boolean Editable { get; set; }
        public Object Value { get; set; }
    }
