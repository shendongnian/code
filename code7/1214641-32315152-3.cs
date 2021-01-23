    IEnumerable<Order> GetOrder(string orderstate)
    {
    	if(orderstate == null)
    	{
    		return null;
    	}
    
    	IQueryable<Order> query = _orderRep.Table;
    
    	if(orderstate == "OrderStateChanged")
    	{
    		query = query.Where(c => c.OrderStateChanged != 0);
    	}
    	else if (orderstate == "PaymentStateChanged")
    	{
    		query = query.Where(c => c.PaymentStateChanged != 0);
    	}
    	/*More else if statement*/
    }
