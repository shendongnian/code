    string myDir = @"D:\Temp\000\";
    Aspose.Pdf.Table table = new Aspose.Pdf.Table();
    table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 1f, Aspose.Pdf.Color.Black);
    table.DefaultCellPadding = new Aspose.Pdf.MarginInfo(5, 5, 5, 5);
    
    Row headerRow = table.Rows.Add();
    headerRow.FixedRowHeight = 100;
    headerRow.DefaultCellTextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
    
    for (int hc = 0; hc < 4; hc++)
    {
        Cell cell = headerRow.Cells.Add();
        cell.BackgroundColor = Aspose.Pdf.Color.Red;
        cell.DefaultCellTextState.ForegroundColor = Aspose.Pdf.Color.White;
        cell.DefaultCellTextState.FontStyle = FontStyles.Bold;
    
        TextFragment h = new TextFragment("header-" + hc);
    
        //Set rotation
        h.TextState.Rotation = 270;
    
        cell.Paragraphs.Add(h);
    }
    
    for (int r = 0; r < 15; r++)
    {
        Row row = table.Rows.Add();
        for (int c = 0; c < 4; c++)
        {
            row.Cells.Add(r + "-" + c);
        }
    }
    
    Document doc = new Document();
    Page page = doc.Pages.Add();
    page.Paragraphs.Add(table);
    doc.Save(myDir + "TextRotate_inCell_17_5.pdf");
