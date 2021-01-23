	public static void ShowDesign(IEnumerable data = null)
	{
		var r = GetLoadedReport();
		if (data != null)
		{
			RegisterData(r, data);
		}
		r.Design();
	}
	public static void PreviewPrint(IEnumerable data)
	{
		var r = GetLoadedReport();
		RegisterData(r, data);
		r.Show();
	}
	private static void RegisterData(Report r, IEnumerable data)
	{
		r.RegisterData(data, "list");
		r.GetDataSource("list").Enabled = true;
	}
	public static Report GetLoadedReport()
	{
		return Report.FromFile(GetReportFilePath());
	}
	public static string GetReportFilePath()
	{
		// return the report file path (.frx file)
	}
