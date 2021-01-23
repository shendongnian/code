    PdfPTable table = new PdfPTable(5);
    table.TotalWidth = 510f;//table size
    table.LockedWidth = true;
    table.SpacingBefore = 10f;//both are used to mention the space from heading
    table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
    table.DefaultCell.Border = PdfPCell.LEFT | PdfPCell.RIGHT;
    table.AddCell(new Phrase("    SL.NO", font1));
    table.AddCell(new Phrase("   SUBJECTS", font1));
    table.AddCell(new Phrase("   MARKS", font1));
    table.AddCell(new Phrase("   MAX MARK", font1));
    table.AddCell(new Phrase("   CLASS AVG", font1));
    Doc.Add(table);
