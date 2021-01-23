	public class TestObject
	{
		public int Col1 { get; set; }
		public int Col2 { get; set; }
		public string Col3 { get; set; }
	}
	[TestMethod]
	public void Number_String_Test()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof(int)), new DataColumn("Col2", typeof(int)), new DataColumn("Col3", typeof(object)) });
		var datalist = new List<TestObject>();
		for (var i = 0; i < 10; i++)
		{
			datalist.Add(new TestObject
			{
				Col1 = i,
				Col2 = i *10,
				Col3 = (i*10) + "E4"
			});
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\numtest.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromCollection(datalist);
			//This would be the variable drawn from the desired cell range
			var range = "C1:C11";
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
