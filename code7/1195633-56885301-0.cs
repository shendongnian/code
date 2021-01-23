    public class Constants
    {
        public Address Headquarters { get; set; }
        public static Constants Instance = new Constants
        {
            Headquarters = new Address { Street = "Baker Street" }
        };
    }
    public class Address
    {
        public string Street { get; set; }
    }
    public class Data
    {
        [GetOnlyJsonProperty]
        // we want this to be included in the response, but not deserialized back
        public Address HqAddress { get { return Constants.Instance.Headquarters; } }
    }
    // somewhere in your code:
    var data = JsonConvert.DeserializeObject<Data>("{'HqAddress':{'Street':'Liverpool Street'}}", settings);
