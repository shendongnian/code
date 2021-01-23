    public class CustomerModule : NancyModule
    {
        public CustomerModule()
        {
            this.Post["api/customers"] = args => this.AddCustomer();
        }
        private Negotiator AddCustomer()
        {
            var customer = this.Bind<Customer>();
            if (customer == null)
            {
                return this.Negotiate.WithStatusCode(HttpStatusCode.BadRequest);
            }
            return this.Negotiate.WithStatusCode(HttpStatusCode.Created);
        }
    }
    public class Customer
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
