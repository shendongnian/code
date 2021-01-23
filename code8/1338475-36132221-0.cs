	var a = new DateTime(2016,12,21, 10, 00, 00);
	var aPlusMonth = a.AddMonths(1);
	Console.WriteLine(a);
	var nextMonth = new DateTime(aPlusMonth.Year, aPlusMonth.Month,1,04,00,00);
	Console.WriteLine(nextMonth);
