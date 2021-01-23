    ExcelNamedStyleXml ns = workBook.Styles.CreateNamedStyle("Good");
    ns.Style.Font.Name = "Calibri";
    ns.Style.Font.Family = 2;
    ns.Style.Font.Size = 11;
    ns.Style.Font.Color.SetColor(0xFF, 0x00, 0x61, 0x00);
    ns.Style.Fill.PatternType = ExcelFillStyle.Solid;
    ns.Style.Fill.BackgroundColor.SetColor(0xFF, 0xC6, 0xEF, 0xCE);
