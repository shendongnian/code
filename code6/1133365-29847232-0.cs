	public class CustomerDetails
	{
	    public int Id {get; set;}
	    public string Name {get; set;}
	}
    public class FindCustomersResult
	{
	    public FindCustomersResult()
		{
		    CustomerDetails = new List<CustomerDetails>();
		}
	    public List<CustomerDetails> CustomerDetails {get; set;}
	}
	public class ApiWrapper
	{
		public Task<FindCustomersResult> FindCustomers(string customerName)
		{
			var tcs = new TaskCompletionSource<FindCustomersResult>(); 
			var client = new MyClient();
			client.FindCustomersCompleted += (object sender, FindCustomersCompletedEventArgs e) => 
				{
					var result = new FindCustomersResult();
					foreach(var customer in e.Customers)
					{
						var customerDetails = await GetCustomerDetails(customer.ID);
						result.CustomerDetails.Add(customerDetails);
					}
					tcs.SetResult(result);
				}
			client.FindCustomersAsync(customerName);	
			return tcs.Task;
		}
		
		public Task<CustomerDetails> GetCustomerDetails(int customerId)
		{
			var tcs = new TaskCompletionSource<CustomerDetails>(); 
			var client = new MyClient();
			client.GetCustomerDetailsCompleted += (object sender, GetCustomerDetailsCompletedEventArgs e) => 
				{
					var result = new CustomerDetails();
				    result.Name = e.Name;
					tcs.SetResult(result);
				}
			client.GetCustomerDetailsAsync(customerId);	
			return tcs.Task;
		}
	}
