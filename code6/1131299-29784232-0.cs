    public class CreditCard
    {
        [SanitizeInLog]
        public string Brand {get; set;}
        
        [SanitizeInLog]
        public string BillingPhone {get; set;}
    }
