    public bool DataExists(string customerId)
    {
     using (var dc = new NorthwindDataContext())
     {
      return dc.CustomerOrders.Any(co => co.CustomerID == customerId);
      // or use the boolean stored procedure
     }
    }
