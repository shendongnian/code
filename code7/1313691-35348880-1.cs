    public class Address
    {
        //...
        //Add this attribute
        [BsonSerializer(typeof(MyCustomArraySerializer))]
        public Coordinate Coord { get; set; }
    }
