    // Imagine list is your main datasource
	IEnumerable<object> list = Enumerable.Empty<object>(); // Data Source of <object>
	
    // Added anon types at runtime added to the object list
	var anonTypesOne = new object[] 
	{ 
		new { GuidID = Guid.NewGuid(), StringProperty = "the string property" },
		new { IntegerID = 1, IntegerProperty = 99 }
	};
	
	var anonTypesTwo = new object[]
	{
		new { StringID = "1", BooleanProperty = true, NumberProperty = 3, StringProperty = "Four" },
		new { GuidID = Guid.NewGuid(), NumberThree = 3 },
		new { GuidID = Guid.NewGuid(), NumberThree = 3 },
		new { GuidID = Guid.NewGuid(), NumberThree = 3 }
	};
	
	list = list.Concat(anonTypesOne).Concat(anonTypesTwo);
	
    // Grouping works on anon types so we can group the export into their own tables
	var groupings = list.GroupBy(i => i.GetType());
	
	using(var package = new ExcelPackage(new FileInfo("C:\\Temp\\Anon.xlsx")))
	{
		var ws = package.Workbook.Worksheets.Add("Anonymous Types");
			
        // add each "anon type matched grouping"
		foreach(var grouping in groupings)
		{
			var isNew = ws.Dimension == null; // the sheet is empty if Dimension is null.
			var row = 0;
			
			if(isNew)
			{
				row = 1; // start from the first row
			}
			else 
			{		
                // otherwise there are tables already, start from the bottom
				row = ws.Dimension.End.Row; 
			}		
			
            // because of EPP inheritance bug of T, we can just use dataTable
			DataTable dt = new DataTable(grouping.Key.Name);
			var properties = grouping.Key.GetProperties(); // Get anon type Properties
			
			foreach(var property in properties)
			{
				dt.Columns.Add(property.Name);
			}
					
			foreach(var item in grouping.ToList())
			{
				var dataRow = dt.NewRow();
				
				foreach(var p in properties) // populate a single row
				{
					dataRow[p.Name] = p.GetValue(item); // item is anon object instance
				}
				
				dt.Rows.Add(dataRow);
			}
			
			if(isNew) // load into the top most left cell of the worksheet
				ws.Cells[1, 1].LoadFromDataTable(dt, PrintHeaders: true);
			else // load from the dimension of current items + 1 row for spacing
				ws.Cells[ws.Dimension.End.Row + 1, 1].LoadFromDataTable(dt, PrintHeaders: true);
				
			ws.InsertRow(ws.Dimension.End.Row + 2, 5); // Insert some padding between each group
			
		}
		
		package.Save();
	}
