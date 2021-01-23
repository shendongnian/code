    public static bool checkDate(DateTime date)
    {
    	var start = new DateTime(1990, 1, 1);
    	
    	return (date - start.Date).Days % 5 == 4;
    }
