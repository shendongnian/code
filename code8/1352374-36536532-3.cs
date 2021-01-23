	public static string TrimFirstTwoMonthChar(string dateInput)
    {
	    var date = Convert.ToDateTime(dateInput);
	    return date.ToString("dd/yyyy"); // Use the format you want here
    }
