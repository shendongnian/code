    doc.Add(new Paragraph("Option 2:"));
    PdfPTable table2 = new PdfPTable(5);
    table2.SpacingBefore = 10;
    int emptycells = 0;
    for (int i = 1; i <= 5; i++)
    {
        if (i == 2 || i == 3)
        {
            // Count the number of empty cells
            emptycells++;
        }
        else
        {
            table2.AddCell(new PdfPCell(new Phrase("Cell " + i)));
        }
    }
    // Add all empty cells at the end
    for (int i = 0; i < emptycells; i++)
    {
        PdfPCell empty2 = new PdfPCell();
        empty2.Border = PdfPCell.NO_BORDER;
        table2.AddCell(empty2);
    }
    doc.Add(table2);
