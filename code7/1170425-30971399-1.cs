        private static ExcelWorksheet CreateSheet(ExcelPackage p,string exportName)
        {
            var epp = new ExportToExcelProperties().WorkbookProperties;
            var prop = epp.Where(t => t.ExportName == "FourCourseAudit").Select(t=>t.Title).Single();
            string sheetName = "Sheet1";
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet worksheet = p.Workbook.Worksheets[1];
            worksheet.Name = sheetName; //Setting Sheet's name
            worksheet.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            worksheet.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet
            // Define worksheet contextual data.
            worksheet.Cells["A1"].Value = "Title: ";
            worksheet.Cells["A2"].Value = "Export Date: ";
            worksheet.Cells["A1:A2"].Style.Font.Bold = true;
            worksheet.Cells["B1"].Value = prop;
            worksheet.Cells["B2"].Value = DateTime.Now;
            worksheet.Cells["B2"].Style.Numberformat.Format = "mm/dd/yyyy hh:mm";
            worksheet.Cells["A1:B2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
            worksheet.Cells["A1:B2"].AutoFitColumns();
            Color bgColor = ColorTranslator.FromHtml("#2956B2");
            worksheet.Cells["A1:B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["A1:B2"].Style.Fill.BackgroundColor.SetColor(bgColor);
            worksheet.Cells["A1:B2"].Style.Font.Color.SetColor(Color.White);
            worksheet.Cells["D1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["D1:F1"].Style.Fill.BackgroundColor.SetColor(bgColor);
            worksheet.Cells["D1:F1"].Style.Font.Color.SetColor(Color.White);
            return worksheet;
        }
        private static OfficeProperties AssignProperties(ExcelPackage p, string exportName)
        {
            // epp is the model where I gather the predefined property values
            var epp = new ExportToExcelProperties().WorkbookProperties;
            var query = from t in epp
                        where t.ExportName == exportName
                        select new { t.Title, t.Comments, t.Category };
            var title = query.Select(t=>t.Title).Single();
            var comments = query.Select(t=>t.Comments).Single();
            var category = query.Select(t=>t.Category).Single();
            OfficeProperties workbookProperties = p.Workbook.Properties;
            workbookProperties.Author = System.Web.HttpContext.Current.User.Identity.Name;
            workbookProperties.Title = title;
            workbookProperties.Comments = comments;
            workbookProperties.Created = DateTime.Now;
            workbookProperties.Category = category;
            return workbookProperties;
        }
