    public class SubscribeModel
    {
       public string UserName {get;set;}
       public string PromoCode {get;set;}
       public PaymentInfo PaymentInfo {get;set;}
    }
    public class UpdateCreditCardModel
    {
       public PaymentInfo PaymentInfo {get;set;}
    }
        
    public class PaymentInfo
    {
       //Payment Info Properties goes here.
    }
