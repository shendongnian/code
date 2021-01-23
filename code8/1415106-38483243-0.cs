    int spacing = 0;
    //The current Y position
    float curY = document.Top;
    //Well ask iText how tall each table was and set the tallest to this variable
    float lineHeight = 0;
    //Maximum number of tables that go on a line
    const int maxPerLine = 3;
    for (int i = 0; i <= 6; i++) {
        PdfPTable table = new PdfPTable(2);
        table.TotalWidth = 144f;
        table.LockedWidth = false;
        PdfPCell cell = new PdfPCell(new Phrase("This is table" + i));
        cell.Colspan = 3;
        cell.HorizontalAlignment = 1;
        table.AddCell(cell);
        table.WriteSelectedRows(0, -1,
            document.Left + spacing, curY,
            writer.DirectContent);
        spacing = spacing + 200;
        //Set the height to whichever is taller, the last table or this table
        lineHeight = Math.Max(lineHeight, table.TotalHeight);
        //If we're at the "last" spot in the "row"
        if (0 == (i + 1) % maxPerLine) {
            //Offset our Y by the tallest table
            curY -= lineHeight;
            //Reset "row level" variables
            spacing = 0;
            lineHeight = 0;
        }
    }
