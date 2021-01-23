    using System;
    using System.Collections.Generic;
    
    public class ShopClass
    {
    	public ShopClass()
    	{
    		Amounts = new Dictionary<string, int>();
    	}
    
    	public string ShopID { get; set; }
    	public Dictionary<string, int> Amounts { get; private set; }
    
    	public void AddAmount(string currency, int amount)
    	{
    		if (Amounts.ContainsKey(currency))
    		{
    			Amounts[currency] = amount;
    		}
    		else
    		{
    			Amounts.Add(currency, amount);
    		}
    	}
    
    	public int? GetAmount(string currency)
    	{
    		if (Amounts.ContainsKey(currency))
    		{
    			return Amounts[currency];
    		}
    
    		return null;
    	}
    
    	public void PrintAmounts()
    	{
    		foreach (var currency in Amounts.Keys)
    		{
    			Console.WriteLine("{0} - {1}: {2}", ShopID, currency, GetAmount(currency));
    		}
    	}
    }
