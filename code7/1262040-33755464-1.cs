    public class AddressObj
    {
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postalcode { get; set; }
        public string address_string { get; set; }
    }
    
    public class Datum
    {
        public AddressObj address_obj { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
