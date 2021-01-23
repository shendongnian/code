    doc.Add(new Paragraph("Option 1:"));
    PdfPTable table = new PdfPTable(5);
    table.SpacingBefore = 10;
    for (int i = 1; i <= 5; i++)
    {
        if (i == 2 || i == 3)
        {
            // Add an empty cell
            PdfPCell empty = new PdfPCell();
            empty.Border = PdfPCell.NO_BORDER;
            table.AddCell(empty);
        }
        else
        {
            table.AddCell(new PdfPCell(new Phrase("Cell " + i)));
        }
    }
    doc.Add(table);
