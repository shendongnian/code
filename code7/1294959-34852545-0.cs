    public class CustomSagePayProvider : SagePayProvider, IOffsitePaymentProcessorProvider
    {
        // Triggered after payments that have been 3D Secure authenticated
        public IPaymentResponse HandleOffsiteNotification(int orderNumber, HttpRequest request, PaymentMethod paymentMethod)
        {
            var paymentResponse = new PaymentResponse() { IsOffsitePayment = true };
            var sagePay = new SagePayIntegration();
            var result = sagePay.GetDirectPaymentResult(request.Params.ToString());
            if (result.ThreeDSecureStatus == ThreeDSecureStatus.OK)
            {
                paymentResponse.IsSuccess = true;
                paymentResponse.GatewayTransactionID = result.TxAuthNo.ToString();
            }
            return paymentResponse;
        }
        public IPaymentResponse HandleOffsiteReturn(int orderNumber, HttpRequest request, PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }
