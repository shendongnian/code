    decimal maxPrice = 0
    
    foreach (product p in products)
    {
    	if (p.Price > maxPrice)
    		maxPrice = p.Price;
    }
    
    foreach (product p in products)
    {
    	if (p.Price == maxPrice)
    		p.Enabled = true;
    	else
    		p.Enabled = false;
    }
