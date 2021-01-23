    public class PaymentMethod : BaseEntity
    {
        public enum MethodTypeEnum
        {
            Creditcard,
            Virtualcard,
            Wallet
        };
        public MethodTypeEnum MethodType { get; set; }
        public int VendorId { get; set; }
        public virtual Address BillingAddress { get; set; }
        
        public string CurrencyCode {get;set;} //Replace with actual column name
         [ForeignKey("CurrencyCode ")]
        public virtual Currency Currency { get; set; }
        
    }
