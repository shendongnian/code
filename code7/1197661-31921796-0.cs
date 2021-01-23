    chartRange = xlsSheet.Range[xlsSheet.Cells[1, 1], xlsSheet.Cells[array.GetLength(0), array.GetLength(1)]];
    chartPage.SetSourceData(chartRange, Excel.XlRowCol.xlRows);
    Excel.Series series = (Excel.Series)chartPage.SeriesCollection(1);
    Excel.Point pt = series.Points(2);
    pt.Format.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbPink;
    chartPage.ChartType = Excel.XlChartType.xl3DColumn;
    chartPage.Location(Excel.XlChartLocation.xlLocationAsNewSheet, oOpt);
