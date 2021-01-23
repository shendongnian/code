	string stringWithDate = "Employee Filter: All Employees; Time Entry Dates: 01/07/2016-01/07/2016; Exceptions: All Exceptions";
	Match match = Regex.Match(stringWithDate, @"\d{2}\/\d{2}\/\d{4}");
	string date = match.Value;
	if (!string.IsNullOrEmpty(date)) {
		var dateTime = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.CurrentCulture);
		Console.WriteLine(dateTime.ToString());
	}
