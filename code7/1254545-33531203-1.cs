    public CustomerRequest
    {
        public Customer customer {get;set;}
        public CustomerRequest(Customer c) 
        {
            this.customer = CheckEmail(c);
        }
       
        private Customer CheckEmail(Customer c) 
        {
            if (c.email == null) throw ArgumentNullException;
            return c;
        }
    }
