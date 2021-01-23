	[TestMethod]
	public void Sheet_To_Table_Test()
	{
		//http://stackoverflow.com/questions/38915006/stripping-data-from-a-epplus-output-from-a-date-range
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Sheet_To_Table.xlsx");
		using (var package = new ExcelPackage(fi))
		{
			var workbook = package.Workbook;
			var worksheet = workbook.Worksheets.First();
			var datatable = new DataTable();
			datatable.Columns.Add("Col1", typeof(int));
			datatable.Columns.Add("Col2", typeof(string));
			datatable.Columns.Add("Col3", typeof(double));
			datatable.Columns.Add("Col4", typeof(DateTime));
			worksheet.ConvertSheetToDataTable(ref datatable);
			foreach (DataRow row in datatable.Rows)
				Console.WriteLine(
					$"row: {{Col1({row["Col1"].GetType()}): {row["Col1"]}" +
					$", Col2({row["Col2"].GetType()}): {row["Col2"]}" +
					$", Col3({row["Col3"].GetType()}): {row["Col3"]}" +
					$", Col4({row["Col4"].GetType()}):{row["Col4"]}}}");
            //To Answer OP's questions
            datatable
                .Select("Col4 >= #01/03/2016#")
                .Select(row => row["Col1"])
                .ToList()
                .ForEach(num => Console.WriteLine($"{{{num}}}"));
		}
	}
