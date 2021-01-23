    public class ClientData
    {
        [ApiElementName("name")]
        public string Name {get; set;}
        [ApiElementName("email")]
        public string Email {get; set;}
    }
    public class PaymentData
    {
        [ApiElementName("payment")]
        public decimal PaymentAmount {get; set;}
        [ApiElementName("description")]
        public string Description {get; set;}
    }
