    public class Person
    {
        public ObjectId _id { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }
        public Person Father { get; set; }
        public string ID { get; set; }
        public double Income { get; set; }
        public string Name { get; set; }
    }
    
    
    public class Address
    {
        public ObjectId _id { get; set; }
        public int HouseNo { get; set; }
        public int ID { get; set; }
        public string Street { get; set; }
    }
