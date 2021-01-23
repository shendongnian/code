    //  Just setting up a dummy package here so I can test your example
    var pckg = new ExcelPackage();
    pckg.Workbook.Worksheets.Add("Test");
    var ws = pckg.Workbook.Worksheets.First(w => w.Name == "Test");
    //  Now that I have a dummy worksheet, I run your code.
    string formula = "2 *2"; //  Note I dropped the equal sign here from your original example
    ws.Cells["q4"].Formula = formula;
    ws.Cells["q4"].Style.Numberformat.Format = "#,##0";
    ws.Workbook.CalcMode = ExcelCalcMode.Automatic;
    ws.Cells["q4"].Calculate();
    if (ws.Cells["q4"].Value.ToString() != null)
    {
        string test = ws.Cells["q4"].Value.ToString();
        MessageBox.Show("the value :" + test);
    }
    else
    {
        MessageBox.Show("not working" );
    }
