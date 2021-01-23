    public CustomerRequest
    {
        public Customer customer {get;set;}
        public CustomerRequest(Customer c) 
        {
            if (c.email == null) throw ArgumentNullException;
            else this.customer = c;
        }
    }
