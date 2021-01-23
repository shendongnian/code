    public class CustomerRequest 
    {
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set 
            {
                if (string.IsNullOrEmpty(value.email))
                {  
                    throw new ArgumentNullException("email");
                }
                _cutomer = value;
            }
        }
    }
