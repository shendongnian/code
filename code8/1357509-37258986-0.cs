         [BsonIgnoreExtraElements]
         public class Topic : Entity
         {
           [BsonElement("title")]
           public string Name { get; set; }
         }
