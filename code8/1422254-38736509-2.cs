    public ActionResult payment(string token)
    {
    	var restClient = new WorldpayRestClient("https://api.worldpay.com/v1", "Your_Service_Key");
    
    	var orderRequest = new OrderRequest()
    	{
    		token = token,
    		amount = 500,
    		currencyCode = CurrencyCode.GBP.ToString(),
    		name = "test name",
    		orderDescription = "Order description",
    		customerOrderCode = "Order code"
    		
    	};
    
    	var address = new Address()
    	{
    		address1 = "123 House Road",
    		address2 = "A village",
    		city = "London",
    		countryCode = CountryCode.GB,
    		postalCode = "EC1 1AA"
    	};
    
    	orderRequest.billingAddress = address;
    
    	try
    	{
    		OrderResponse orderResponse = restClient.GetOrderService().Create(orderRequest);
    		Console.WriteLine("Order code: " + orderResponse.orderCode);
    	}
    	catch (WorldpayException e)
    	{
    		Console.WriteLine("Error code:" + e.apiError.customCode);
    		Console.WriteLine("Error description: " + e.apiError.description);
    		Console.WriteLine("Error message: " + e.apiError.message);
    	}
    	return Json(null, JsonRequestBehavior.AllowGet);
    }
