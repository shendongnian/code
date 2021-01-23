    public class ChildItemViewModel
    {
        [BsonElement("Id")]
        public long Id { get; set; }
        public string Description { get; set; }
        public long SequentialOrgId { get; set; }
    }
