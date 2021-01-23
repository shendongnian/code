    Excel.Application app = new Excel.Application();
    
    try
    {
        app.DisplayAlerts = false;
        app.Visible = false;
        Excel.Workbook book = app.Workbooks.Open("D:\\test.xlsx");
        book.SaveAs(Filename: "D:\\test.txt", FileFormat: Excel.XlFileFormat.xlUnicodeText,
            AccessMode: Excel.XlSaveAsAccessMode.xlNoChange,
            ConflictResolution: Excel.XlSaveConflictResolution.xlLocalSessionChanges);
    }
    finally
    {
        app.Quit();
    }
