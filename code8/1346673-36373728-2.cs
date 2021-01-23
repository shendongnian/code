	[TestMethod]
	public void Table_Delete_Test()
	{
		//http://stackoverflow.com/questions/36359047/unable-to-delete-table-using-epplus
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = i; row[1] = i * 10; row[2] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		var fi = new FileInfo(@"c:\temp\Table_Delete_Test.xlsx");
		if (fi.Exists)
			fi.Delete();
		//Create a worksheet with tables to later open and look for tables (note that EPPlus does not create the table objects until save)
		using (var pck = new ExcelPackage(fi))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("source");
			worksheet.Cells["A1"].LoadFromDataTable(datatable, true);
			worksheet.Cells["A12"].LoadFromDataTable(datatable, true);
			var table1 = worksheet.Tables.Add(worksheet.Cells["A1:C11"], "TableTest1");
			var table2 = worksheet.Tables.Add(worksheet.Cells["A12:C22"], "TableTest2");
			pck.Save();
		}
		//Open the test workbook and delete the second table
		using (var pck = new ExcelPackage(fi))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.First();
			var wsXml = worksheet.WorksheetXml;
			var nsm = new XmlNamespaceManager(wsXml.NameTable);
			var nsuri = wsXml.DocumentElement.NamespaceURI;
			nsm.AddNamespace("m", nsuri);
			//Remove reference to the second table which should be last
			var tablePartsNode = wsXml.SelectSingleNode("m:worksheet/m:tableParts", nsm);
			tablePartsNode.RemoveChild(tablePartsNode.LastChild);
			pck.Save();
		}
	}
