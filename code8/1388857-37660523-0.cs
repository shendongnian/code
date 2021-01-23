    public class BillOutcomeClass
    {
        public string LargeMessage { get; set; }
        public string MobileMessage { get; set; }
        public string Value { get; set; }
        protected Customer Cust { get; set; }
        protected Account Acct { get; set; }
    
        public BillOutcomeClass(string acctNumber, HttpContext currentContext)
        {
            this.Cust = CustomerSecurity.GetCustomer(currentContext);
            this.Acct = customer.GetAccountForTransaction(acctNumber);
        }
    }
