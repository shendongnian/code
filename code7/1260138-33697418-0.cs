	[TestMethod]
	public void Chart_Row_Offset_Test()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Col1", typeof (DateTime)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] =  DateTime.Now.AddDays(i) ;row[1] = i*10;row[2] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Chart_Row_Offset.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			//This would be the axis label format if the XML Attribute is not set below
			worksheet.Cells["A2:A11"].Style.Numberformat.Format = "m/d/yyyy";
			const int EXCELCHARTWIDTH = 375;
			const int EXCELCHARTHEIGHT = 350;
			const double EXCELDEFAULTROWHEIGHT = 20.0; //Assuming standard screen dpi
			var startCell = (ExcelRangeBase)worksheet.Cells["A1"];
			for (var i = 0; i < 10; i++)
			{
				var chart = worksheet.Drawings.AddChart("chart " + i, eChartType.XYScatterLines);
				chart.SetSize(EXCELCHARTWIDTH, EXCELCHARTHEIGHT);
				chart.SetPosition(startCell.Start.Row, 0, startCell.Start.Column, 0);
				chart.XAxis.Format = "yyyy-mm-dd";
				var series = chart.Series.Add(worksheet.Cells["B2:B11"], worksheet.Cells["A2:A11"]);
				var chartcellheight = (int)Math.Ceiling(EXCELCHARTHEIGHT / EXCELDEFAULTROWHEIGHT);
				startCell = startCell.Offset(chartcellheight, 0);
				//Get reference to the chart xml for proper namespace
				var xdoc = chart.ChartXml;
				var nsm = new XmlNamespaceManager(xdoc.NameTable);
				nsm.AddNamespace("default", xdoc.DocumentElement.NamespaceURI);
				//Add the attribute to not link to the source data format
				var att = xdoc.CreateAttribute("sourceLinked");
				att.Value = "0";
				var numFmtNode = xdoc.SelectSingleNode("/default:chartSpace/default:chart/default:plotArea/default:valAx/default:numFmt", nsm);
				numFmtNode.Attributes.Append(att);
			}
			pck.Save();
		}
	}
