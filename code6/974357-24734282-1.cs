    public class PaymentResponse
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
	    public string intent {get; set; }
	    public Payer payer{get; set; }
    }
    public class Payer
    {
        public string payment_method {get;set;}
        public PayerInfo payer_info {get;set;}
    }
    public class PayerInfo
    {
        public string email { get; set; }
	    public string first_name { get; set; }
    }
