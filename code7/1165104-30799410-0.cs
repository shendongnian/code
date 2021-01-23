    var something = new xxx.ApplicationClass[4];
    for (int i = 0; i < 3; i++)
    {
        something[i] = new (Microsoft.Office.Interop.Excel.Worksheet)appExcel.Worksheets.Add(Type.Missing, appExcel.Worksheets[appExcel.Worksheets.Count], 1, XlSheetType.xlWorksheet);
        something[i].Name = "sheet" + (i + 1).ToString();
    }
