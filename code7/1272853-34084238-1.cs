    public ActionResult PaymentsAndPromotions()
	{
		var order = new Order();
	    return View(order);
	}
	[HttpPost]
	public ActionResult PaymentsAndPromotions(Order order)
	{
	    //you can get all your order's property here. 
	    //example:
	    if (order.CreditCardNum != "test123")
	    {
	    
	    }
	    return View(order);
	}
