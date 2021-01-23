	try
    {
		var result = new ImportResult();
		s = System.Web.HttpContext.Current.Request.GetBufferedInputStream();
		using (var sr = new System.IO.StreamReader(s))
		{
			s = null;
			var reader = new CsvReader(sr, new CsvConfiguration
			{
				Delimiter = ";"
			});
			var records = reader.GetRecords<RowEntry>();
			...
		}
		return result;
	}
	finally
	{
		s?.Dispose();
	}
