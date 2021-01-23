    var customer = new Customer 
    { 
    	Name = "Darth Vader", 
    	Age = 45,
    	Orders = new List<Order> 
    	{
    		new Order { Id = 1, Details = "Order1" },
    		new Order { Id = 2, Details = "Order2" }
    	}
    };
    string json = JsonConvert.SerializeObject(customer);
