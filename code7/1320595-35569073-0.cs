    private static void AddHyperLinkStyle(ExcelWorkbook wb)
    {
        if (!wb.Styles.NamedStyles.Any(x => x.Name == "Hyperlink"))
        {
            var s = wb.Styles.CreateNamedStyle("Hyperlink");
            s.Style.Font.UnderLine = true;
            s.Style.Font.Color.SetColor(Color.Blue);
        }
    }
