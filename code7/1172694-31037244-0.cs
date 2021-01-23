	public static void Main()
	{
		var today = "1/8/2015";
        // create the string arrays to hold the dates from the text files.     Initialize to null.
        List<string> dateLinesWeek = null;
        List<string> dateLinesMonth = null;
        // this is the text file that contains the dates for week-end run dates.
		dateLinesWeek = new List<string>() {
			"1/1/2015", 
			"1/8/2015", 
			"1/15/2015", 
			"1/22/2015", 
			"1/29/2015"
		};
		dateLinesMonth= new List<string>() 
		{
			"1/15/2015", 
			"2/15/2015", 
			"3/15/2015"
		};
		
		if (dateLinesMonth.Contains(today))
		{
			Console.WriteLine("Execute B");
		}
		else if(dateLinesWeek.Contains(today))
		{
			Console.WriteLine("Execute A");
		}
