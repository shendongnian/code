    var date = DateTime.Today;
    var query =
    	from customer in context.Customers
    	where customer => customer.IsEnabled
    	select new 
    	{
    		customer,
    		contract = customer.Contracts.FirstOrDefault(c => c.ContractEndDate >= date && c.ContractStartDate <= date)
    	};
    var result = new List<CustomerOverviewDto>();
    foreach (var entry in query)
    {
        CustomerOverviewDto customerDto = GetCustomer(entry.customer);
        if (entry.contract != null)
            SetContract(customerDto, entry.contract);
        result.add(customerDto);
    }
 
