    doc.Add(new Paragraph("Option 3:"));
    // Determine the number of empty cells before hand
    int emptycellsCounted = 2;
    PdfPTable table3 = new PdfPTable(5 - emptycellsCounted);
    table3.SpacingBefore = 10;
    for (int i = 1; i <= 5; i++)
    {
        if (i == 2 || i == 3)
        {
            // Do nothing
        }
        else
        {
            table3.AddCell(new PdfPCell(new Phrase("Cell " + i)));
        }
    }
    doc.Add(table3);
    
    doc.Close();
