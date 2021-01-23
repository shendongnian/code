    using (ExcelEngine excelEngine = new ExcelEngine())
    {
      IApplication application = excelEngine.Excel;
      application.DefaultVersion = ExcelVersion.Excel2013;
      IWorkbook workbook = application.Workbooks.Create(1);
      IWorksheet sheet = workbook.Worksheets[0];
      //Setting values to the cells
      sheet.Range["A1"].Number = 10;
      sheet.Range["B1"].Number = 10;
      //Setting formula in the cell
      sheet.Range["C1"].Formula = "=SUM(A1,B1)";
      // Enabling CalcEngine for computing the formula
      sheet.EnableSheetCalculations();
      string computedValue = sheet.Range["C1"].CalculatedValue;
      workbook.SaveAs("Formula.xlsx");
      // Disabling the CalcEngine
      sheet.DisableSheetCalculations();
    }
