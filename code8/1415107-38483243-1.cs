    var outerTable = new PdfPTable(3);
    outerTable.DefaultCell.Border = PdfPCell.NO_BORDER;
    for (int i = 0; i <= 6; i++) {
        PdfPTable innerTable = new PdfPTable(2);
        innerTable.TotalWidth = 144f;
        innerTable.LockedWidth = false;
        PdfPCell cell = new PdfPCell(new Phrase("This is table" + i));
        cell.Colspan = 3;
        cell.HorizontalAlignment = 1;
        innerTable.AddCell(cell);
        outerTable.AddCell(innerTable);
        
    }
    document.Add(outerTable);
