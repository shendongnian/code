    public partial class OrderWS
    {
        private FulfillmentWS[] fulfillmentListField;
    }
    
    public partial class FulfillmentWS
    {
        public Customer fulfillingCustomerField { get; set; };
    
        public string fulfillingOutletIdField { get; set; };
    }
