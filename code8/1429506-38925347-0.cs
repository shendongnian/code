	public static void ConvertSheetToDataTable(this ExcelWorksheet worksheet, ref DataTable dataTable)
	{
		//DateTime Conversion
		var convertDateTime = new Func<double, DateTime>(excelDate =>
		{
			if (excelDate < 1)
				throw new ArgumentException("Excel dates cannot be smaller than 0.");
			var dateOfReference = new DateTime(1900, 1, 1);
			if (excelDate > 60d)
				excelDate = excelDate - 2;
			else
				excelDate = excelDate - 1;
			return dateOfReference.AddDays(excelDate);
		});
		//Get the names in the destination TABLE
		var tblcolnames = dataTable
			.Columns
			.Cast<DataColumn>()
			.Select(dcol => new {Name = dcol.ColumnName, Type = dcol.DataType})
			.ToList();
		//Cells only contains references to cells with actual data
		var cellGroups = worksheet.Cells
			.GroupBy(cell => cell.Start.Row)
			.ToList();
		//Assume first row has the column names and get the names of the columns in the sheet that have a match in the table
		var colnames = cellGroups
			.First()
			.Select((hcell, idx) => new { Name = hcell.Value.ToString(), index = idx })
			.Where(o => tblcolnames.Select(tcol => tcol.Name).Contains(o.Name))
			.ToList();
		//Add the rows - skip the first cell row
		for (var i = 1; i < cellGroups.Count(); i++)
		{
			var cellrow = cellGroups[i].ToList();
			var tblrow = dataTable.NewRow();
			dataTable.Rows.Add(tblrow);
			colnames.ForEach(colname =>
			{
				//Excel stores either strings or doubles
				var cell = cellrow[colname.index];
				var val = cell.Value;
				var celltype = val.GetType();
				var coltype = tblcolnames.First(tcol => tcol.Name ==  colname.Name).Type;
				//If it is numeric it is a double since that is how excel stores all numbers
				if (celltype == typeof(double))
				{
					//Unbox it
					var unboxedVal = (double)val;
					
					//FAR FROM A COMPLETE LIST!!!
					if (coltype == typeof (int))
						tblrow[colname.Name] = (int) unboxedVal;
					else if (coltype == typeof (double))
						tblrow[colname.Name] = unboxedVal;
					else if (coltype == typeof (DateTime))
						tblrow[colname.Name] = convertDateTime(unboxedVal);
					else
						throw new NotImplementedException($"Type '{colname.Name}' not implemented yet!");
				}
				else
				{
					//Its a string
					tblrow[colname.Name] = val;
				}
			});
		}
		
	}
