    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(WorkWithWorkbook);
    }
    private void WorkWithWorkbook(Microsoft.Office.Interop.Excel.Workbook workbook)
    {
        // Workbook has been opened. Do stuff here.
        var app = Globals.ThisAddIn.Application;
        Excel.Workbook wb = app.ThisWorkbook;
    }
