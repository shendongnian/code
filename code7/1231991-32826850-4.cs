    public class Delivery
    {
        public string Id { get; set; }
        public string Address { get; set; }
    
        public Delivery(string id, string address)
        {
            Id = id;
            Address = address;
        }
    }
