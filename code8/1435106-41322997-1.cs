    static void test4()
    {
        var fs = new System.IO.FileInfo(@"c:\temp\test4.xlsx");
        if (fs.Exists) fs.Delete();
    
        using (ExcelPackage package = new ExcelPackage(fs))
        {
    
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Test"];
            if (worksheet == null) worksheet = package.Workbook.Worksheets.Add("Test");
            var WS = worksheet;
            WS.Workbook.CalcMode = ExcelCalcMode.Manual;
    
            // strings with .
            WS.Cells[1, 1].Value = "100.0";
            WS.Cells[2, 1].Value = "42.1";
            using (var sum = WS.Cells[3, 1])
            {
                sum.Formula = "SUM(A1:A2)";
                sum.Calculate();
            }
    
            // strings with ,
            WS.Cells[1, 2].Value = "100,0";
            WS.Cells[2, 2].Value = "42,1";
            using (var sum = WS.Cells[3, 2])
            {
                sum.Formula = "SUM(B1:B2)";
                sum.Calculate();
            }
    
            // strings with ,
            WS.Cells[1, 3].Value = "1,100";
            WS.Cells[2, 3].Value = "42";
            using (var sum = WS.Cells[3, 3])
            {
                sum.Formula = "SUM(C1:C2)";
                sum.Calculate();
            }
    
            // let EPPLUS handle it 
            WS.Cells[1, 4].Value = 100; // int
            WS.Cells[2, 4].Value = 42.1d; // double
            using (var sum = WS.Cells[3, 4])
            {
                sum.Formula = "SUM(D1:D2)";
                sum.Calculate();
            }
    
            package.Save();
        }
    }
