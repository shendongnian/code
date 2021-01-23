    var excelApp = new Microsoft.Office.Interop.Excel.Application();
    string filePath = "E:/111.xlsx";
    var xs=excelApp.Workbooks.Open(filePath);
    Microsoft.Office.Interop.Excel._Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;
    workSheet.Cells[3, "A"] = textBox1.Text;
    workSheet.Cells[7, "F"] = textBox2.Text;
    excelApp.Workbooks.Close();`
