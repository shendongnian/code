    Microsoft.Office.Interop.Excel.Application excel = new  Microsoft.Office.Interop.Excel.Application();
    string str = @"C:\myExcelFile.xlsx";
    Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(Filename: str);
    Microsoft.Office.Interop.Excel.Worksheet worksheet1 = workbook.ActiveSheet;
    Microsoft.Office.Interop.Excel.Range range = worksheet1.get_Range("A1","A1");
    Microsoft.Office.Interop.Excel.DropDowns xlDropDowns;
    Microsoft.Office.Interop.Excel.DropDown xlDropDown;
    xlDropDowns = ((Microsoft.Office.Interop.Excel.DropDowns)(workbook.ActiveSheet.DropDowns(Type.Missing)));
