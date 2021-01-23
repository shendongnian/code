    using (ExcelEngine excelEngine = new ExcelEngine())
    {
        //Instantiate the excel application object.
        IApplication application = excelEngine.Excel;
        application.DefaultVersion = ExcelVersion.Excel2013;
        //Create a workbook with single worksheet
        IWorkbook workbook = application.Workbooks.Create(1);
        IWorksheet worksheet = workbook.Worksheets[0];
        //Style definition 
        IStyle style = workbook.Styles.Add("Border");
        style.Borders.Color = ExcelKnownColors.Black;
        style.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
        style.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
        style.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
        style.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
        //Import data table
        worksheet.ImportDataTable(GetDataTable(), true, 1, 1);
        //Assgin created border
        worksheet.UsedRange.CellStyle = style;
        //Autofit columns
        worksheet.UsedRange.AutofitColumns();
        //Save the excel document
        using (MemoryStream excelStream = new MemoryStream())
        {
            workbook.SaveAs(excelStream);
            workbook.Close();
            excelStream.Position = 0;
            System.Net.Mail.Attachment oAttachment = new System.Net.Mail.Attachment(excelStream, "DataTableImported.xlsx");
        }
    }
