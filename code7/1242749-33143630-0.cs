    //only handles new orders...as is
    //Assumes!!! Order is of a type which is a db Entity! (Table)
    //Assumes that you populated "order" with all the required properties.
    public Order Post([FromBody]Order order) 
    {
    	db.Orders.Add(order);
    	db.SaveChanges();
    	return order;
    }
