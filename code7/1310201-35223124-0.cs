    // I've changed 9 into 5, because you are only adding 5 cells in each row:
    PdfPTable table = new PdfPTable(5);
    table.TotalWidth = 595;
    // there isn't any content in the table: there's nothing to write yet
    // Header row.
    table.AddCell(GetCell("Header 1", 1, 2));
    table.AddCell(GetCell("Header 2", 1, 2));
    table.AddCell(GetCell("Header 3", 5, 1));
    table.AddCell(GetCell("Header 4", 1, 2));
    table.AddCell(GetCell("Header 5", 1, 2));
    // Inner middle row.
    table.AddCell(GetCell("H1"));
    table.AddCell(GetCell("H2"));
    table.AddCell(GetCell("H3"));
    table.AddCell(GetCell("H4"));
    table.AddCell(GetCell("H5"));
    
    // Now we've added 2 rows: two rows will be shown:
    table.WriteSelectedRows(0, -1, 300, 300, pcb);
