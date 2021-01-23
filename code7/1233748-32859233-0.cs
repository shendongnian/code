    using System;
					
    public class Program
     {
 	public static void Main()
	{
		var date = "12/29/2014 00:00:00.000";
		
		IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        DateTime checkindate = Convert.ToDateTime(date, culture);
       Console.WriteLine(checkindate);
	  }
    }
