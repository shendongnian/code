    Microsoft.Office.Interop.Excel.Application xlApp;
    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    object misValue = System.Reflection.Missing.Value;
    DataSet ds = new DataSet();
    XmlReader xmlFile;
    xlApp = new Microsoft.Office.Interop.Excel.Application();
    xlWorkBook = xlApp.Workbooks.Add(misValue);
    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    xmlFile = XmlReader.Create(@"C:\example.xml", new XmlReaderSettings());
    ds.ReadXml(xmlFile);
    object[,] objects = new object[ds.Tables[0].Rows.Count, ds.Tables[0].Columns.Count];
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
        {
            objects[i, j] = ds.Tables[0].Rows[i][j].ToString();
        }
    }
    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.get_Range("A1", "D3");
    range.Value = objects;
    releaseObject(range);
    xlWorkBook.SaveAs("C:\\PerformanceMonitorExcel " + DateTime.Now.ToString("dd_MM_yyyy") + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
    xlWorkBook.Close(true, misValue, misValue);
    xlApp.Quit();
    releaseObject(xlApp);
    releaseObject(xlWorkBook);
    releaseObject(xlWorkSheet);
    MessageBox.Show("finished");
