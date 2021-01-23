	private string ConstructExcelShortDatePattern()
	{
		var systemDateComponentCodes = new DateFormatComponentCodes();
		var excelDateComponentCodes = new DateFormatComponentCodes(this.application);
		
        string systemShortDatePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
		string excelShortDatePattern = systemShortDatePattern.Replace(systemDateComponentCodes.Year, excelDateComponentCodes.Year).Replace(systemDateComponentCodes.Month, excelDateComponentCodes.Month).Replace(systemDateComponentCodes.Day, excelDateComponentCodes.Day);
		return excelShortDatePattern;
	}
