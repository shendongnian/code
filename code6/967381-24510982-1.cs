    using System;
    using System.Globalization;
					
    public class Program
    {
	public static void Main()
	{
		double amount = 39.55;
		var decimalPoint = (amount * 10).ToString();
		
		if(decimalPoint.Contains(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator))
			Console.WriteLine(string.Format(new CultureInfo("en-US"),"{0:C2}", amount));
		else
			Console.WriteLine(string.Format(new CultureInfo("en-US"),"{0:C1}", amount));
			
		
	}
    }
