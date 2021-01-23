    var pieChart = worksheet.Drawings.AddChart("Chart1", eChartType.Pie);
    var series = pieChart.Series.Add(worksheet.Cells[2, 2, data.Count, 2], worksheet.Cells[2, 1, data.Count, 1]);
    var pieSeries = (ExcelPieChartSerie)series;
    pieSeries.DataLabel.Position = eLabelPosition.InBase;
    pieChart.Legend.Position = eLegendPosition.Right;
