    using (ExcelEngine excelEngine = new ExcelEngine())
    {
        //Instantiate the excel application object.
        IApplication application = excelEngine.Excel;
    
        application.DefaultVersion = ExcelVersion.Excel2013;
    
        //Open the workbook
        IWorkbook workbook = application.Workbooks.Open("Input.xlsx");
        
        (workbook.Worksheets as WorksheetsCollection).Add("NewSheet");
    
        IWorksheet worksheet = workbook.Worksheets[1];
    
        IConditionalFormats condition = worksheet.Range["A1"].ConditionalFormats;
    
        IConditionalFormat condition1 = condition.AddCondition();
    
        condition1.FormatType = ExcelCFType.CellValue;
    
        condition1.Operator = ExcelComparisonOperator.Between;
    
        condition1.FirstFormula = "10";
    
        condition1.SecondFormula = "20";
    
        condition1.BackColor = ExcelKnownColors.Red; 
    
        worksheet.Range["A1"].Number = 13;
    
        //Save the workbook
        workbook.SaveAs("AddedWorkbook.xlsx");
    }
