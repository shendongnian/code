	string[] sDatetimeFormat2 = { "HH:mm tt", "h:m t", "HH:mm:ss",
                             "HH:mm:ss tt", "h:m:s t", "H:mm tt", "h:mm tt"};
		
	DateTime tsInput;
	var InputDateOrTime = "2:22 PM";
	DateTime.TryParseExact(InputDateOrTime.Replace("\"", ""), sDatetimeFormat2, new CultureInfo("en-US"), DateTimeStyles.None,  out tsInput);
	Console.WriteLine(tsInput);
