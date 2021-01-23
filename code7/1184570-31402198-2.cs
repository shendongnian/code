    public void Process(IName entity)
    {
         LogOperation( entity.FullName );
    
       // If we have an order process it uniquely
       var order = entity as IOrder;
    
       if (order != null)
       {
          LogOperation( "Order: " + order.Amount.ToString() );
       }
    
    }
