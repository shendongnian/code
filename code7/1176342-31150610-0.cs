	[TestMethod]
	public void ListToDataTableConverter()
	{
		//Use a func for demonstrative purposes
		Func<List<NameAgeObject>, DataTable> ToDataTable = (items) =>
		{
			DataTable dataTable = new DataTable(typeof(NameAgeObject).Name);
			//Get all the properties
			PropertyInfo[] Props = typeof(NameAgeObject).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name);
			}
			foreach (NameAgeObject item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					//inserting property values to datatable rows
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			//put a breakpoint here and check datatable
			return dataTable;
		};
		var itemlist = new List<NameAgeObject>
		{
			new NameAgeObject {Name = "A", Age = 22},
			new NameAgeObject {Name = "B", Age = 23},
			new NameAgeObject {Name = "C", Age = 24},
			new NameAgeObject {Name = "D", Age = 25},
			new NameAgeObject {Name = "E", Age = 26},
		};
		var dtdata = ToDataTable(itemlist);
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var package = new ExcelPackage(existingFile))
		{
			var ws = package.Workbook.Worksheets.Add("Sheet1");
			ws.Cells[1, 1].LoadFromDataTable(dtdata, false);
			package.Save();
		}
	}
