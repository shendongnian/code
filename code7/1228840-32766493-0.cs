	[TestMethod]
	public void AutoFilter_Test()
	{
		//http://stackoverflow.com/questions/32723483/adding-a-specific-autofilter-on-a-column
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof(int)), new DataColumn("Col2", typeof(int)), new DataColumn("Col3", typeof(object)) });
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow(); row[0] = i; row[1] = i * 10;row[2] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\autofilter.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			var range = worksheet.Cells["A1:C10"];
			range.AutoFilter = true;
			
			pck.Save();
		}
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.First();
			//Get reference to the worksheet xml for proper namespace
			var xdoc = worksheet.WorksheetXml;
			var nsm = new XmlNamespaceManager(xdoc.NameTable);
			nsm.AddNamespace("default", xdoc.DocumentElement.NamespaceURI);
			//Create the filters themselves
			var filter1 = xdoc.CreateNode(XmlNodeType.Element, "filter", xdoc.DocumentElement.NamespaceURI);
			var att = xdoc.CreateAttribute("val");
			att.Value = "40";
			filter1.Attributes.Append(att);
			var filter2 = xdoc.CreateNode(XmlNodeType.Element, "filter", xdoc.DocumentElement.NamespaceURI);
			att = xdoc.CreateAttribute("val");
			att.Value = "50";
			filter2.Attributes.Append(att);
			//Add filters to the collection
			var filters = xdoc.CreateNode(XmlNodeType.Element, "filters", xdoc.DocumentElement.NamespaceURI);
			filters.AppendChild(filter1);
			filters.AppendChild(filter2);
			//Create the parent filter container
			var filterColumn = xdoc.CreateNode(XmlNodeType.Element, "filterColumn", xdoc.DocumentElement.NamespaceURI);
			att = xdoc.CreateAttribute("colId");
			att.Value = "1";
			filterColumn.Attributes.Append(att);
			filterColumn.AppendChild(filters);
			//Now add it to the autoFilters node
			var autoFilter = xdoc.SelectSingleNode("/default:worksheet/default:autoFilter", nsm);
			autoFilter.AppendChild(filterColumn);
			//Have to manually hide rows based on criteria
			worksheet.Cells
				.Where(cell =>
					cell.Address.StartsWith("B") 
					&& cell.Value is double 
					&& (double) cell.Value != 40d 
					&& (double) cell.Value != 50d)
				.Select(cell => cell.Start.Row)
				.ToList()
				.ForEach(r => worksheet.Row(r).Hidden = true);
			pck.Save();
		}
	}
