    public sealed class HttpRequestVersionSelectorPaymentData : IPaymentData
    {
        private readonly PaymentData paymentOld;
        private readonly PaymentDataNew paymentNew;
        public VersionSelectorPaymentData(PaymentData old, PaymentDataNew paymentNew) { ... }
        private bool New => HttpContext.Current.Items["version"] as string ?? "1") == "2";
        private IPaymentData PaymentData => this.New ? paymentNew : paymentOld;
        // IPaymentData method(s)
        public Payment GetData(int id) => this.PaymentData.GetData(id);
    }
