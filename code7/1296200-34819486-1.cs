    [HttpGet("/")]
    public IActionResult Create()
    {
    	var user = userRepository.Get(1);
    
    	var order = new Order
    	{
    		Address = user.Addresses[0].Address1,
    		City = user.Addresses[0].City,
    		State = user.Addresses[0].State,
    		Zip = user.Addresses[0].Zip,
    		User = user,
    		SubTotal = 100,
    		Tax = 25,
    		Total = 125
    	};
    
    	orderRepository.Add(order);
    	orderRepository.SaveChanges();
    
    	return RedirectToAction("Index");
    }
