    		Console.WriteLine("deal with regex datetime: ");
			string input = "11/24 5:41:00 AM";
			DateTime newDate;
			CultureInfo enUS = new CultureInfo("en-US");
			try
			{
				newDate = DateTime.ParseExact(input, "M/d h:mm:ss tt", CultureInfo.InvariantCulture);
				Console.WriteLine("parse result: " + newDate);
			}
			catch (Exception err)
			{
				Console.WriteLine("error parsing input string. date format is wrong or string chaged " + err);
			}
