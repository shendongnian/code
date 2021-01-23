    public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        [BsonRepresentation(BsonType.ObjectId)]
        public string Boss_Id { get; set; }
    
        public string Emp_Name { get; set; }
    }
