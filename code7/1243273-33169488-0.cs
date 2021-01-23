      private void btnGetXLSValue_Click(object sender, EventArgs e)
      {
           
            object _row = 5;
            object _column = 5;
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelApp.ScreenUpdating = false;
            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook ;//= excelApp.Workbooks.Open(@"C:\July.xlsm", 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get a reference to the Workbook object by using a file moniker.
            //The xls was saved earlier with this file name.
            excelWorkbook = (Excel.Workbook)System.Runtime.InteropServices.Marshal.BindToMoniker(@"C:\July.xlsm"); 
            Microsoft.Office.Interop.Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "July 2015";
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(currentSheet);
            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)excelWorksheet.UsedRange;
            string sValue = (range.Cells[_row, _column] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
            //string sValue = (range.Cells[_row, _column] as Microsoft.Office.Interop.Excel.Range).get_Value(range).ToString();
            MessageBox.Show(sValue);
        }
