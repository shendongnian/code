    void FormatRange(Excel.Range target)
    {
        target.Style.Font.Bold = true;
        target.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        target.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; 
        target.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSkyBlue);
    }
