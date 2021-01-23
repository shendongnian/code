    using Microsoft.Office.Interop.Excel
    
    string path = @"C:\testoutput\output.xlsx";
    
    Microsoft.Office.Interop.Excel.Application oXL;
    Microsoft.Office.Interop.Excel.Workbook oBook;
    Microsoft.Office.Interop.Excel.Worksheet oSheet;
    Microsoft.Office.Interop.Excel.Range oRng;
    
    oXL = new Microsoft.Office.Interop.Excel.Application();
    oXL.Visible = false; //This can be fun to leave enabled though :)
    oXL.UserControl = false;
    
    oBook = oXL.Workbooks.Add();
    oSheet = oBook.ActiveSheet;
    //This part can take a while, so throwing it into an async method elsewhere may be a thought
    for (int x = 0; x < gv.Rows.Count; x++)
    {
        for (int y = 0; y < gv.Columns.Count; y++)
        {
            oSheet.Cells[x + 2, y + 1] = gv.Rows[x].Cells[y].ToString();
        }
    }
    oBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
    
    oBook.Close(); //Don't forget this because the program will not close it automatically!!!
