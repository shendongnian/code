    public class CartViewModel
    {
        public int SelectedPaymentMethod { get; set; }
        public IEnumerable<PaymentMethods> PaymentMethods { get; set; }
    }
