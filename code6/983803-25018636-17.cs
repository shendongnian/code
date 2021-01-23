    public class ClientData
    {
        public string Name {get; set;}
        public string Email {get; set;}
    }
    // customer really insisted that the property is
    // named `PaymentAmount` as opposed to simply `Amount`,
    // so we'll add a custom attribute here
    public class PaymentData
    {
        [MyApiName("payment")]
        public decimal PaymentAmount {get; set;}
        public string Description {get; set;}
    }
