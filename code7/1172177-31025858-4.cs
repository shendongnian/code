    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // <== Or any culture you like
    List<string> monthNames = new List<string>(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames);
	foreach (string month in months)
	{
		if (System.IO.Directory.Exists("C:\\Desktop\\Month\\" + month))
		{
			DropDownList1.Items.Add(month + " 2015");
		}
	}
	
