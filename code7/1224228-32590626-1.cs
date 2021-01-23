    [TestMethod]
	public void Number_String_Test()
	{
		//http://stackoverflow.com/questions/32587834/epplus-loadfromcollection-text-converted-to-number
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof(int)), new DataColumn("Col2", typeof(int)), new DataColumn("Col3", typeof(object)) });
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow(); row[0] = i; row[1] = i * 10;
			row[2] = (i * 10) + "E4"; //makes it string
			datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\numtest.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			//This would be the variable drawn from the desired cell range
			var range = "C2:C11";
			//Get reference to the worksheet xml for proper namspace
			var xdoc = worksheet.WorksheetXml;
			//Create the import nodes (note the plural vs singular
			var ignoredErrors = xdoc.CreateNode(XmlNodeType.Element, "ignoredErrors", xdoc.DocumentElement.NamespaceURI);
			var ignoredError = xdoc.CreateNode(XmlNodeType.Element, "ignoredError", xdoc.DocumentElement.NamespaceURI);
			ignoredErrors.AppendChild(ignoredError);
			//Attributes for the INNER node
			var sqrefAtt = xdoc.CreateAttribute("sqref");
			sqrefAtt.Value = range;
			var flagAtt = xdoc.CreateAttribute("numberStoredAsText");
			flagAtt.Value = "1";
			ignoredError.Attributes.Append(sqrefAtt);
			ignoredError.Attributes.Append(flagAtt);
			//Now put the OUTER node into the worksheet xml
			xdoc.LastChild.AppendChild(ignoredErrors);
			pck.Save();
		}
	}
