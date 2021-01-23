    string Filetest = "C:\\Users\\Tom\\Documents\\File.xls";
    Excel.Application oApp;
    Excel.Workbook obook;
    oApp = new Excel.Application();
    if (File.Exists(Filetest))
    {
        obook = oApp.Workbooks.Open(Filetest);
    }
    else
    {
        obook = oApp.Workbooks.Add();
    }
 
    var oSheet = (Excel.Worksheet)obook.Worksheets.get_Item(1);
    oSheet.Cells[i, 1] = comboBox1.Text;
    // etc
    obook.SaveAs(Filetest);
    obook.Close();
    oApp.Quit();
