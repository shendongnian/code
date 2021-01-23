    List<CustomerOverviewDto> result = new List<CustomerOverviewDto>();    
    
    customers = context.Customers.Where(c => c.IsEnabled).ToList();
    contracts = context.Contracts.Where(c => c.ContractEndDate >= DateTime.Today && c.ContractStartDate <= DateTime.Today).ToList();
    
    foreach (Customer customer in customers)
    {
    	var customerDto = GetCustomer(customer);
    	var contract = contracts.Where(c => c.CustomerId == customer.Id).FirstOrDefault();
    	if (contract != null)
    	{
    		SetContract(customerDto, contract);
    	}
    	
    	result.add(customerDto);
    }
