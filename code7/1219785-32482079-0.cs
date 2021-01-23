    Document doc = new Document();
    DocumentBuilder builder = new DocumentBuilder(doc);
    
    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
    
    //Start table
    builder.StartTable();
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.First;
    builder.Write("One");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.First;
    builder.Write("Two");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.None;
    builder.CellFormat.HorizontalMerge = CellMerge.First;
    builder.Write("Header");
    
    builder.InsertCell();
    builder.CellFormat.HorizontalMerge = CellMerge.Previous;
    builder.Write("Header");
    
    builder.InsertCell();
    builder.CellFormat.HorizontalMerge = CellMerge.None;
    builder.CellFormat.VerticalMerge = CellMerge.First;
    builder.Write("Column");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.First;
    builder.Write("Column");
    builder.EndRow();
    
    //Insert second Row
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.Previous;
    builder.Write("One");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.Previous;
    builder.Write("Two");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.None;
    builder.Write("First");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.None;
    builder.Write("Second");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.Previous;
    builder.Write("Column");
    
    builder.InsertCell();
    builder.CellFormat.VerticalMerge = CellMerge.Previous;
    builder.Write("Column");
    builder.EndRow();
    
    builder.CellFormat.VerticalMerge = CellMerge.None;
    builder.CellFormat.HorizontalMerge = CellMerge.None;
    for (int i = 0; i < 10; i++)
    {
        builder.InsertCell();
        builder.Write("Cell 1");
    
        builder.InsertCell();
        builder.Write("Cell 2");
    
        builder.InsertCell();
        builder.Write("Cell 3");
    
        builder.InsertCell();
        builder.Write("Cell 4");
    
        builder.InsertCell();
        builder.Write("Cell 5");
    
        builder.InsertCell();
        builder.Write("Cell 6");
        builder.EndRow();
    }
    
    //End the table
    builder.EndTable();
    
    doc.Save(MyDir + "Out.docx");
