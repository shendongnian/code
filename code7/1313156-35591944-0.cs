	[TestMethod]
	public void Chart_Meged_Header_Test()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Col1", typeof (string)),
			new DataColumn("Col2", typeof (int))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = $"item {(i%2 == 0 ? "A" : "B")}";
			row[1] = i * 10;
			datatable.Rows.Add(row);
		}
		
		//Create a test file    
		var fileInfo = new FileInfo(@"c:\temp\Chart_Meged_Header_Test.xlsx");
		if (fileInfo.Exists)
			fileInfo.Delete();
		using (var pck = new ExcelPackage(fileInfo))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("Sheet1");
			worksheet.Cells["B1"].LoadFromDataTable(datatable, true);
			worksheet.Column(4).Style.Numberformat.Format = "m/d/yyyy";
			var chart = worksheet.Drawings.AddChart("chart test", eChartType.BarClustered);
			var serie = chart.Series.Add(worksheet.Cells["C2:C11"], worksheet.Cells["B2:B11"]);
			chart.SetPosition(1, 0, 3, 0);
			//Add merged headers
			worksheet.Cells["A2"].Value = "Group 1";
			worksheet.Cells["A2:A6"].Merge = true;
			worksheet.Cells["A7"].Value = "Group 2";
			worksheet.Cells["A7:A11"].Merge = true;
			//Get reference to the worksheet xml for proper namespace
			var chartXml = chart.ChartXml;
			var nsm = new XmlNamespaceManager(chartXml.NameTable);
			var nsuri = chartXml.DocumentElement.NamespaceURI;
			var mainuri = "http://schemas.openxmlformats.org/drawingml/2006/main";
			nsm.AddNamespace("c", nsuri);
			nsm.AddNamespace("a", mainuri);
			//Get the Series ref and its cat
			var serNode = chartXml.SelectSingleNode("c:chartSpace/c:chart/c:plotArea/c:barChart/c:ser", nsm);
			var catNode = serNode.SelectSingleNode("c:cat", nsm);
			
			//Get Y axis reference to replace with multi level node
			var numRefNode = catNode.SelectSingleNode("c:numRef", nsm);
			var multiLvlStrRefNode = chartXml.CreateNode(XmlNodeType.Element, "c:multiLvlStrRef", nsuri);
			//Set the proper cell reference and replace the node
			var fNode = chartXml.CreateElement("c:f", nsuri);
			fNode.InnerXml = numRefNode.SelectSingleNode("c:f", nsm).InnerXml;
			fNode.InnerXml = fNode.InnerXml.Replace("$B$2", "$A$2");
			multiLvlStrRefNode.AppendChild(fNode);
			catNode.ReplaceChild(multiLvlStrRefNode, numRefNode);
			//Set the multi level flag
			var noMultiLvlLblNode = chartXml.CreateElement("c:noMultiLvlLbl", nsuri);
			var att = chartXml.CreateAttribute("val");
			att.Value = "0";
			noMultiLvlLblNode.Attributes.Append(att);
			var catAxNode = chartXml.SelectSingleNode("c:chartSpace/c:chart/c:plotArea/c:catAx", nsm);
			catAxNode.AppendChild(noMultiLvlLblNode);
			pck.Save();
		}
	}
