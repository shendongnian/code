        public IEnumerable<Customer> Customers
        {
            get
            {
                return this.customers;
            }
            set
            {
                this.customers = value;
                this.OnPropertyChanged();
            }
        }
