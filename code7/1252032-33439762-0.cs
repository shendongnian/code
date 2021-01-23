    static int ReadItemsCountFromInput()
    {
    	while(true)
    	{
    		Console.WriteLine("enter items count: ");
    		string s = Console.ReadLine();
    		int r;
    		if(int.TryParse(s, out r) && r > 0)
    		{
    			return r;
    		}
    		else
    		{
    			Console.WriteLine("you should enter number greater than zero");
    		}
    	}
    }
    
    static double CalculateShipping(int items, double shippingCharge)
    {
            if (items == 1)
                shippingCharge = 2.99;
            else if (items > 1 && items < 6)
                shippingCharge = 2.99 + 1.99 * (items - 1);
            else if (items > 5 && items < 15)
                shippingCharge = 10.95 + 1.49 * (items - 5);
            else if (items > 14)
                shippingCharge = 24.36 + 0.99 * (items - 14);
    		return shippingCharge;
    }
    	
    static void Main()
    {
    	int items = ReadItemsCountFromInput();
    	double result = CalculateShipping(items, 0);
    	Console.WriteLine("Shipping: {0}", result);
    }
