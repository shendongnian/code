    public class CheckoutStub : IContent
    {
        public bool IsCheckedOut { get; private set; }
        public void CheckOut() { IsCheckedOut = true; }
    }
