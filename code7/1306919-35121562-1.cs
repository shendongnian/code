    public IEnumerable<Orders> Orders(int? customerNumber){
      var query = dbContext.Orders;
    
      if (customerNumber.hasValue)
      {
        query = query.Where(c=>c.Id == customerNumber.value)
      }
      return query.ToList();
    
    }
