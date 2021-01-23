    public partial class FulfillmentWS 
    {
        private Customer fulfillingCustomerField;
        public Customer FulFillingCustomer
        {
            get { return fulfillingCustomerField; }
            set { fulfillingCustomerField = value; }
        }
        private string fulfillingOutletIdField;
        public string FulFillingOutletId
        {
            get { return fulfillingOutletIdField; }
            set { fulfillingOutletIdField = value; }
        }
    }
