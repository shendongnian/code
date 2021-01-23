    public class CustomEntity
    {
        public string Id { get; set; }
        public string StringProperty { get; set; }
        public DateTime? DateTimeProperty { get; set; }
    }
    var filterIfStringPropertyNull = Builders<CustomEntity>.Filter.Eq(o => o.StringProperty, null); // if property is string
 
    var filterIfDatePropertyNull = Builders<CustomEntity>.Filter.Eq(o => o.DateTimeProperty, BsonNull.Value.ToNullableUniversalTime());  // if property is DateTime?
