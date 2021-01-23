    table.SetWidths(new float[] { 1f, 0.1f, 1f });
    PdfPCell cell1 = new PdfPCell(new Phrase("Cell1"));
    table.AddCell(cell1);
    
    //dummy cell created to have an empty space with width `0.1f` which was declared //above.
    PdfPCell cell2 = new PdfPCell(new Phrase(""));
    table.AddCell(cell2);
    
    PdfPCell cell3 = new PdfPCell(new Phrase("Cell3"));
    table.AddCell(cell3);
