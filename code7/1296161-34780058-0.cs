    public interface IPaymentRequest 
    {
    }
    //This class will be shipped to your clients. 
    public class PaymentRequestDTO: IPaymentRequest
    {
    } 
    
    //This class will be used in your WebAPI or Server Side code.
    [Validator(typeof(PaymentRequestValidator))]
    public class PaymentRequest: IPaymentRequest
    {
    } 
    
