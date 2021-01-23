    //Old way
        public string Name
        {
            get
            {
                return "David";
            }
        }
        //New way
        public string Name => "David";
		
        //old way 
        public Address GetAddressByCustomerId(int customerId)
        {
            return AddressRepository.GetAddressByCustomerId(customerId);
        }
        //New Way
        public Address GetAddressByCustomerId(int customerId) => AddressRepository.GetAddressByCustomerId(customerId);
