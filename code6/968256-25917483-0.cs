    // Add a Table to this document.
    var table = document.AddTable(2, 3);
    
    // Specify some properties for this Table.
    table.Alignment = Alignment.center;
    
    // Add content to this Table.
    table.Rows[0].Cells[0].Paragraphs.First().Append("A");
    table.Rows[0].Cells[1].Paragraphs.First().Append("B");
    table.Rows[0].Cells[2].Paragraphs.First().Append("C");
    table.Rows[1].Cells[0].Paragraphs.First().Append("D");
    table.Rows[1].Cells[1].Paragraphs.First().Append("E");
    table.Rows[1].Cells[2].Paragraphs.First().Append("F");
    
    // Insert table at index where tag #TABLE# is in document.
    document.InsertTable(table));
    foreach (var paragraph in document.Paragraphs)
    {
        paragraph.FindAll("#TABLE#").ForEach(index => paragraph.InsertTableAfterSelf((table)));
    }
    
    //Remove tag
    document.ReplaceText("#TABLE#", ""); 
