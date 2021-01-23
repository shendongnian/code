    try
    {
        application = new Excel.Application();
        workbooks = application.Workbooks;
        worbook = workbooks.Open(path);
        worksheet = workbook.ActiveSheet;
        range = worksheet.UsedRange;
        ...
        application.Quit();
    }
    finally
    {  
        if (range != null)
        {
             Marshal.FinalReleaseComObject(application);
        }
        if (worksheet != null)
        {
             Marshal.FinalReleaseComObject(worksheet);
        }
        ...
        if (application != null)
        {
             Marshal.FinalReleaseComObject(application);
        }
    }
