    var json = "[{\"id\": 0,\"name\": \"Test\",\"price\": 0.1},{\"id\": 0,\"name\": \"Test2\",\"price\": 0.1}]";
    var result = JsonConvert.DeserializeObject<List<RootObject>>(json);
    public class RootObject
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "price")]
        public double Price { get; set; }
    }
