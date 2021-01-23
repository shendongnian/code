    var input = "w/c 07/03/2016 AT 17/03/2016 w/c 25/04/2016";
		
	// Find dates
	var dates = Regex.Matches(input,@"\d{2}\/\d{2}\/\d{2,4}");
		
	foreach(Match date in dates)
    {
		// Use a placeholder to store your date
		DateTime d = DateTime.MinValue;
	    if(DateTime.TryParseExact(date.Value,"dd/MM/yyyy",null,DateTimeStyles.None,out d))
		{
				// The date was properly parse, so compare it
				if(d > DateTime.Now)
				{
                    // Your date is larger, handle accordingly
					Console.WriteLine(d + " is greater than today");
				}
				else
				{
                    // Your date is smaller, handle accordingly
					Console.WriteLine(d + " is less than today");
				}
			}
		}
        else
        {
             // Your date was in the wrong format, do something
        }
    }
