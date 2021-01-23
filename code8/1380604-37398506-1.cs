	//explicit operator
	public static explicit operator CustomerData(Customer c){
		var customerData = new CustomerData();
		customerData.Name = c.Name;
		customerData.Addresses = c.Addresses;
		return customerData;
	}
