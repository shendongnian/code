    string dst = dataDir + "table.doc";
    
    Aspose.Words.Document doc = new Aspose.Words.Document();
    DocumentBuilder builder = new DocumentBuilder(doc);
    
    // Set margins
    doc.FirstSection.PageSetup.LeftMargin = 10;
    //doc.FirstSection.PageSetup.TopMargin = 0;
    doc.FirstSection.PageSetup.RightMargin = 10;
    //doc.FirstSection.PageSetup.BottomMargin = 0;
    
    // Set oriantation
    doc.FirstSection.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
    
    Aspose.Words.Tables.Table table = builder.StartTable();
                
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            builder.InsertCell();
            // Fixed width
            builder.CellFormat.Width = ConvertUtil.InchToPoint(0.5);
            builder.Write("Column : " + j);
        }
        builder.EndRow();
    }
    builder.EndTable();
    
    // Set table auto fit behavior to fixed width columns
    table.AutoFit(AutoFitBehavior.FixedColumnWidths);
    
    doc.Save(dst, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));
