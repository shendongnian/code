    public class CustomerServices : ICustomerServices
    {
        private readonly EntitiesContext context;
        public CustomerServices(EntitiesContext context) {
            this.context = context;
        }
        public void CreateCustomer(string customerName, string homeAddress,
            string shippingAddress)
        {
            // NOTE that I renamed 'Customers' to 'Customer', since it holds information
            // to only one customer. 'Customers' implies a collection.
            Customer cust = new ShopEntities.Customer();
            cust.CustName = "Sam";
            cust.IAddress = "xyz";
            cust.ShippingAddress = "xyz xyx xyz"; 
            this.context.Customers.Add(cust);
            this.context.SubmitChanges();
        }
        public void ChangeShippingAddress(...) { ... }
    }
