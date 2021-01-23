    Smart.Format("{Name} from {Address.City}, {Address.State}", user)
    // The user object should at least be like that 
    public class User
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
    }
