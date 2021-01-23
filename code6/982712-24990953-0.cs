    [Give("excel is started with workbook '(.*)'")]
    public void StartExcel(string workbook)
    {
        using Excel = Microsoft.Office.Interop.Excel; 
        Excel.Application excel = new Excel.Application();
        excel.Visible = true;        
        Excel.Workbook excelWorkbook = excel.Workbooks.Open(workbook);
    }
