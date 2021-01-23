    using System;
    using System.Globalization;
					
    public class Program
    {
	public static void Main()
	{
		double amount = 39.5555;
		
		string decimalPoint = (amount).ToString();
		
		decimalPoint = decimalPoint.Substring(decimalPoint.IndexOf(".") + 1);
		
		if(	decimalPoint.Length > 0)
			Console.WriteLine(string.Format(new CultureInfo("en-US"),"{0:C" + decimalPoint.Length +"}", amount));
		else
			Console.WriteLine(string.Format(new CultureInfo("en-US"),"{0:C}", amount));
	}
    }
