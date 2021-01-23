    string[][] SenorityList = SalesEmployees.OrderBy(innerArray =>
			{
				if (innerArray.Length >= 5)
				{
					DateTime startDate;
					if (DateTime.TryParse(innerArray[4], out startDate))
						return startDate;
				}
				// if you want that unpasrsed dates will be on the end of the list use DateTime.MaxValue
				return DateTime.MaxValue;
			}).ToArray();
