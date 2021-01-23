    double[] HousePriceInDollars = { 3.4, 5.2, 1.2, 0.7, 2.6, 2.7, 3.0 };
    List<double> NewPrice = new List<double>();
	foreach (var cost in HousePriceInDollars)
	{
	    NewPrice.Add(cost * 8);
	}
	
	double[] NewPriceInSek = NewPrice.ToArray();
