    using System;
    using System.Collections.Specialized;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		NameValueCollection nvcFormVariables = new NameValueCollection();
    		nvcFormVariables.Add("Amount","1356");
    	
    		//string sAmount = "13.56";
    		int amount = int.Parse(nvcFormVariables["Amount"]);		
    		Console.WriteLine(amount);
    		decimal amountPaid = amount / 100;		
    		Console.WriteLine(amountPaid);
    		
    		decimal dAmount = decimal.Parse(nvcFormVariables["Amount"]);
    		Console.WriteLine(dAmount);
    		decimal dAmountPaid = dAmount / 100;		
    		Console.WriteLine(dAmountPaid);
    		
    	}
    }
