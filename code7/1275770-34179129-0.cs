    PdfPTable table = new PdfPTable(1);
    table.TotalWidth = 696f;
    PdfPCell cell = new PdfPCell(new Phrase("Hello World!", new Font(Font.ARIAL, 12f, Font.NORMAL, Color.BLACK)));
    cell.BorderColor = new Color(0,0,0);
    cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
    cell.BorderWidthLeft = 2f;
    cell.BorderWidthRight = 2f;
    table.AddCell(cell);
