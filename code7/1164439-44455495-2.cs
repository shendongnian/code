    public void PlaceOrder(Order order)
    {
         BeginTransaction();
         Try 
         {
             SaveOrderToDataBase(order);
             ev = new OrderPlaced(Order);
             SaveEventToDataBase(ev);
             CommitTransaction();
         }
         Catch 
         {
              RollbackTransaction();
              return;
         }
       
         PublishEventAsync(ev);    
    }
    async Task PublishEventAsync(BussinesEvent ev) 
    {
        BegintTransaction();
        try 
        {
             await DeleteEventAsync(ev);
             await bus.PublishAsync(ev);
             CommitTransaction();
        }
        catch 
        {
             RollbackTransaction();
        }
    }
