    public decimal GetPrice(decimal price)
    {
      return price
    }
    
    public decimal GetPrice(decimal price, int qty)
    {
    	return GetPrice(price) * quantity
    }
    
    public decimal GetPrice(decimal price, int qty, decimal tax)
    {
    	return GetPrice(price, qty) * tax
    }
