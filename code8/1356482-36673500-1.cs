    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public int CustomerId { get; set; }
        public int PostCodeId { get; set; }
    }
    public class PostCode
    {
        public int PostCodeId { get; set; }
        public string Code { get; set; }
    }
