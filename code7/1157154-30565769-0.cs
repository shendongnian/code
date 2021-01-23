	using System;
	using System.Globalization;
	public class Program
	{
		public static void Main()
		{
			DateTime dateParsed = DateTime.Now;	
			if ( DateTime.TryParseExact( "2015-06-01T02:31:00+0000", "yyyy-MM-ddThh:mm:ss+0000", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out dateParsed ) ) {
				Console.WriteLine(string.Format("Parsing done: {0:MM/dd/yyyy @ hh:mm}", dateParsed ) );
			} else {
				Console.WriteLine("No result");
			}
		}
	}
