	namespace DateTest1
	{
		using System;
		using System.Collections.Generic;
		using System.Globalization;
		class Program
		{
			static void Main(string[] args)
			{
				var intervals = new List<Tuple<string, string>>
									{
										new Tuple<string, string>("01/01/15", "11/01/15"),
										new Tuple<string, string>("02/01/15", "04/01/15"),
										new Tuple<string, string>("09/01/15", "13/01/15"),
										new Tuple<string, string>("18/01/15", "20/01/15")
									};
				var totalNights = 0;
				foreach (var interval in intervals)
				{
					var dateFrom = DateTime.ParseExact(interval.Item1, "dd/MM/yy", CultureInfo.InvariantCulture);
					var dateTo = DateTime.ParseExact(interval.Item2, "dd/MM/yy", CultureInfo.InvariantCulture);
					var nights = dateTo.Subtract(dateFrom).Days;
					Console.WriteLine("{0} - {1}: {2} nights", interval.Item1, interval.Item2, nights);
					totalNights += nights;
				}
				Console.WriteLine("Total nights: {0}", totalNights);
			}
		}
	}
----------
	01/01/15 - 11/01/15: 10 nights
	02/01/15 - 04/01/15: 2 nights
	09/01/15 - 13/01/15: 4 nights
	18/01/15 - 20/01/15: 2 nights
	Total nights: 18
	Press any key to continue . . .
