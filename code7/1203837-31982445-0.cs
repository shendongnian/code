    public static void Main()
    	{
            DayOfWeek firstWeekDay = DayOfWeek.Monday;
    		DateTime input = DateTime.Now;
    		int delta = firstWeekDay - input.DayOfWeek;
    		DateTime monday = input.AddDays(delta);
    		var array = Enumerable.Range(0, 7).Select(x => monday.AddDays(x).ToString("dd MMM")).ToArray();
    		Console.WriteLine("{0}", string.Join(" | ", array));
    	}
