	if(DateTime.TryParseExact(input, customCulture.DateTimeFormat.ShortDatePattern, 
                              customCulture, DateTimeStyles.None, out myDate))
	{
		MessageBox.Show("Date cannot be parsed!");
	}
