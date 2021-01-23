    return new [] 
    {  
       new DesignWiseTotal
       {
           GrandTotal = query.Where(oi => oi.Product.Designer_Id == customerId)
                             .Sum(oi => oi.PriceExclTax);
       }
    }.ToList();
