	// double primaryCost = 0.0;
    double totalCost = 0.0;
    double purchaseItem = Convert.ToDouble(item);
    if (purchaseItem >= 50.0)
    {
        totalCost = (purchaseItem / 100.0) * 10.0;
    }
.../...
	if (secondaryItem >= 50.00)
    {
        double secondaryCost = (secondaryItem / 100.0) * 10.0;
        totalCost += secondaryCost;
    }
