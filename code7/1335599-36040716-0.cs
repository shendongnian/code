    public class Myclass
    {
        public string Name { get; set; }
        public DateTime Date{ get; set; }
    }
    serializer.Deserialize<Myclass>(bson);
