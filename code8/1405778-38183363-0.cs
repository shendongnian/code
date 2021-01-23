    Excel.Workbook workbook = null;
    Excel.Worksheet workSheet = null;
    Excel.Range range = null;
    try
    {
        workbook = excel.Workbooks[1];
        workSheet = workbook.Worksheets.get_Item(1);
        range = workSheet.UsedRange;
        . . . 
    }
    catch(Exception ex)
    {
    }
    finally
    {
        if (range != null)
            Marshal.FinalReleaseComObject(range);
        if (worksheet != null)
            Marshal.FinalReleaseComObject(worksheet);
        if (workbook != null)
            Marshal.FinalReleaseComObject(workbook);
    
        //  Garbage collection
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, false);
    }
       
