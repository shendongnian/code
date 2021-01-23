	IEnumerable<string> columnNames;
	var workSheetName = excel.GetWorksheetNames().FirstOrDefault();
	if (string.IsNullOrEmpty(workSheetName))
	{
        //For CSV files there are not worksheet names
		var worksheet = excel.Worksheet();
		if (worksheet == null)
		{
			throw new ApplicationException("Unable to extract data. The file contains no data");
		}
		var row = worksheet.FirstOrDefault();
		if (row == null)
		{
			throw new ApplicationException("Unable to extract data. The file contains no rows");
		}
		columnNames = row.ColumnNames;
	}
	else
	{
		columnNames = excel.GetColumnNames(workSheetName);
	}
	if (columnNames == null || !columnNames.Any())
	{
		throw new ApplicationException("Unable to extract column information.");
	}
