    public static void ExportDataSetToExcel()
    {
        Excel.Application objXL = null;
        Excel.Workbook objWB = null;
        objXL = new Microsoft.Office.Interop.Excel.Application();
        objXL.Visible = true;
        objWB = objXL.Workbooks.Add(1);
        Excel.Worksheet objSHT = objWB.Sheets.Add();
        for (int row = 1; row < 100000; row++)
        {
            objSHT.Cells[row, 1].Value2 = row;
        }
        objWB.SaveAs("c:\test\test.xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);
        objWB.Close();
        objXL.Quit();
    }
