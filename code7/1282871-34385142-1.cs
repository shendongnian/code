    public class SelectedCustomerEvent 
    {
        public Customer Customer { get; }
        public SelectedCustomerEvent(Customer customer) 
        {
            // C# 6.0, otherwise add a private setter
            Customer = customer;
        }
    }
