    public class Location
    {
       public Object Id { get; set; }
       [BsonIgnoreIfDefault]
       public double latitude { get; set; }
       [BsonIgnoreIfDefault]
       public double longitude { get; set; }
       [BsonIgnoreIfDefault]
       public String LocDescription { get; set; }
    }
