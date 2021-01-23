    using Microsoft.Office.Interop.Excel;
    ...
    var missing = Type.Missing;
    using (AutoReleaseComObject<Microsoft.Office.Interop.Excel.Application> excelApplicationWrapper = new AutoReleaseComObject<Microsoft.Office.Interop.Excel.Application>(new Microsoft.Office.Interop.Excel.Application()))
    {
        excelApplicationWrapper.ComObject.Visible = true;
        try
        {
            using (AutoReleaseComObject<Workbook> workbookWrapper = new AutoReleaseComObject<Workbook>(excelApplicationWrapper.ComObject.Workbooks.Open(@"C:\Temp\ExcelMoveChart.xlsx", false, false, missing, missing, missing, true, missing, missing, true, missing, missing, missing, missing, missing)))
            {
                var workbookComObject = workbookWrapper.ComObject;
                Worksheet sheetSource = workbookComObject.Sheets["Sheet1"];
                ChartObject chartObj = (ChartObject)sheetSource.ChartObjects("Chart 3");
                Chart chart = chartObj.Chart;
                chart.Location(XlChartLocation.xlLocationAsObject, "Sheet2");
            }
        }
        finally
        {
            excelApplicationWrapper.ComObject.Quit();
        }
    }
