    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    object misValue = System.Reflection.Missing.Value;
    
    string myPath = tbFolderpath.Text + tbFileName.Text;//User Given Path Value
    FileInfo fi = new FileInfo(myPath);
    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    if (!fi.Exists)//To Check File exist in a location,if not exist it will create new file
    {
     xlWorkBook = xlApp.Workbooks.Add(misValue);
     xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
     xlWorkSheet.Cells[1, "A"] = "Name";
     xlWorkSheet.Cells[1, "B"] = "Age";
     xlWorkSheet.Cells[1, "C"] = "CurrentTime";
     var columnHeadingsRange = xlWorkSheet.Range[xlWorkSheet.Cells[1, "A"], 
                               xlWorkSheet.Cells[1, "C"]];
     columnHeadingsRange.Interior.Color = Excel.XlRgbColor.rgbYellow;//To Give Header Color
     xlWorkBook.SaveAs(myPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, 
                       misValue,misValue, misValue, misValue, 
                       Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, 
                       misValue, misValue, misValue, misValue, misValue);
    }
    //Already File Exist it will open the File and update the data into excel`enter code here`
    var workbook = xlApp.Workbooks.Open(myPath);
    xlWorkSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
    int _lastRow = xlWorkSheet.Range["A" +xlWorkSheet.Rows.Count]. 
                   End[Excel.XlDirection.xlUp].Row + 1;
    xlWorkSheet.Cells[_lastRow, "A"] = Textbox1.Text;
    xlWorkSheet.Cells[_lastRow, "B"] = Textbox2.Text;
    DateTime currentTime = DateTime.Now;//To Get the Current Time
    string formattedTime = currentTime.ToString("dd/MM/yyyy-hh:mm:ss");
    xlWorkSheet.Cells[_lastRow, "C"] = formattedTime;
    workbook.Save();
    workbook.Close();
    xlApp.Quit();
