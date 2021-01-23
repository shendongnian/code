    public class Client
    {
        public string ClientId { get; set; }
    }
    public class RootObject // Same as you wrapper
    {
        public IList<Client> Client { get; set; }
    }
