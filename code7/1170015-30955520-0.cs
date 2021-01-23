    public class Payment {
        private readonly IPaymentGateway _paymentGateway;
        public Payment(IPaymentGateway paymentGateway) {
            _paymentGateway = paymentGateway;
        }
        public MyMethod() {
            //get your models prepared etc.
            _paymentGateway.MakePayment(cardDetails, addressDetails);
        }
