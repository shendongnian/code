	DateTime date = DateTime.Now;
	DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
	var firstDayOfTheWeek = date.AddDays(firstDay - date.DayOfWeek);
	Console.WriteLine(firstDayOfTheWeek);
	int weekNumber = firstDayOfTheWeek.DayOfYear / 7; // In case you want this information as well.
	Console.WriteLine(weekNumber);
