    using Microsoft.Office.Interop.Excel;
    ...
    var missing = Type.Missing;
    using (AutoReleaseComObject<Microsoft.Office.Interop.Excel.Application> excelApplicationWrapper = new AutoReleaseComObject<Microsoft.Office.Interop.Excel.Application>(new Microsoft.Office.Interop.Excel.Application()))
    {
        var excelApplicationWrapperComObject = excelApplicationWrapper.ComObject;
        excelApplicationWrapperComObject.Visible = true;
    
        var excelApplicationWrapperComObjectWkBooks = excelApplicationWrapperComObject.Workbooks;
        try
        {
            using (AutoReleaseComObject<Workbook> workbookWrapper = new AutoReleaseComObject<Workbook>(excelApplicationWrapperComObjectWkBooks.Open(@"C:\Temp\ExcelMoveChart.xlsx", false, false, missing, missing, missing, true, missing, missing, true, missing, missing, missing, missing, missing)))
            {
                var workbookComObject = workbookWrapper.ComObject;
                Worksheet sheetSource = workbookComObject.Sheets["Sheet1"];
                ChartObject chartObj = (ChartObject)sheetSource.ChartObjects("Chart 3");
                Chart chart = chartObj.Chart;
                chart.Location(XlChartLocation.xlLocationAsObject, "Sheet2");
    
                ReleaseObject(chart);
                ReleaseObject(chartObj);
                ReleaseObject(sheetSource);
    
                workbookComObject.Close(false);
            }
        }
        finally
        {
            excelApplicationWrapperComObjectWkBooks.Close();
            ReleaseObject(excelApplicationWrapperComObjectWkBooks);
    
            excelApplicationWrapper.ComObject.Application.Quit();
            excelApplicationWrapper.ComObject.Quit();
            ReleaseObject(excelApplicationWrapper.ComObject.Application);
            ReleaseObject(excelApplicationWrapper.ComObject);
    
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();    
        }
    }
    private static void ReleaseObject(object obj)
    {
        try
        {
            while (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 0);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            Console.WriteLine("Unable to release the Object " + ex.ToString());
        }
    }
