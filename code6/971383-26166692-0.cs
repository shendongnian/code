	public void PieChartCreate()
	{
		var file = new FileInfo(@"c:\temp\temp.xlsx");
		if (file.Exists)
			file.Delete();
		var pck = new ExcelPackage(file);
		var workbook = pck.Workbook;
		var worksheet = workbook.Worksheets.Add("newsheet");
		var data = new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>("Group A", 44613),
			new KeyValuePair<string, int>("Group B", 36432),
			new KeyValuePair<string, int>("Group C", 6324),
			new KeyValuePair<string, int>("Group A", 6745),
			new KeyValuePair<string, int>("Group B", 23434),
			new KeyValuePair<string, int>("Group C", 5123),
			new KeyValuePair<string, int>("Group A", 34545),
			new KeyValuePair<string, int>("Group B", 5472),
			new KeyValuePair<string, int>("Group C", 45637),
			new KeyValuePair<string, int>("Group A", 37840),
			new KeyValuePair<string, int>("Group B", 20827),
			new KeyValuePair<string, int>("Group C", 4548),
		};
		//Fill the table
		var startCell = worksheet.Cells[1,1];
		startCell.Offset(0, 0).Value = "Group Name";
		startCell.Offset(0, 1).Value = "Value";
		for (var i = 0; i < data.Count(); i++)
		{
			startCell.Offset(i + 1, 0).Value = data[i].Key;
			startCell.Offset(i + 1, 1).Value = data[i].Value;
		}
		//Add the chart to the sheet
		var pieChart = worksheet.Drawings.AddChart("Chart1", eChartType.Pie);
		pieChart.SetPosition(data.Count + 1, 0, 0, 0);
		pieChart.Title.Text = "Test Chart";
		pieChart.Title.Font.Bold = true;
		pieChart.Title.Font.Size = 12;
		//Set the data range
		var series = pieChart.Series.Add(worksheet.Cells[2, 2, data.Count, 2], worksheet.Cells[2, 1, data.Count, 1]);
		var pieSeries = (ExcelPieChartSerie)series;
		pieSeries.Explosion = 5;
		//Format the labels
		pieSeries.DataLabel.Font.Bold = true;
		pieSeries.DataLabel.ShowValue = true;
		pieSeries.DataLabel.ShowPercent = true;
		pieSeries.DataLabel.ShowLeaderLines = true;
		pieSeries.DataLabel.Separator = ";";
		pieSeries.DataLabel.Position = eLabelPosition.BestFit;
		//Format the legend
		pieChart.Legend.Add();
		pieChart.Legend.Border.Width = 0;
		pieChart.Legend.Font.Size = 12;
		pieChart.Legend.Font.Bold = true;
		pieChart.Legend.Position = eLegendPosition.Right;
		pck.Save();
	}
