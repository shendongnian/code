    		for (int i = 0; i < 100; i++)
			{
				var year = 1900 + i;
				DateTime date = new DateTime(year, 1, 1);
				var parsedDate = DateTime.ParseExact(date.ToString("yy"), "yy", CultureInfo.InvariantCulture);
				Console.WriteLine("{0}: {1}", year, parsedDate.ToString("yyyy"));
			}
