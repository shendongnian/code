    public class Employee : IEmployee
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
