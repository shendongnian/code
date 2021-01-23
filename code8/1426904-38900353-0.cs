    public class Student {
      [BsonId]
      [BsonRepresentation(BsonType.String)]
      public string Id { get; set; }
      public string Name { get; set; }
      public int Age { get; set; }
      public Course[] Courses { get; set; }
    }
    public class Course {
      [BsonId]
      [BsonRepresentation(BsonType.String)]
      public string Id { get; set; }
      public string Name { get; set; }
      public string Level { get; set; }
    }
