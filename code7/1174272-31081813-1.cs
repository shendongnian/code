    pdfTable.AddCell(dt.Rows[intIndex]["date"].ToString());
    pdfTable.AddCell(dt.Rows[intIndex]["time"].ToString());
    pdfTable.AddCell(dt.Rows[intIndex]["result"].ToString());
    pdfTable.AddCell(dt.Rows[intIndex]["fullname"].ToString());
    pdfTable.AddCell(dt.Rows[intIndex]["regarding"].ToString());
    cell = new PdfPCell(new Phrase(dt.Rows[intIndex]["details"].ToString()));
    cell.Colspan = 6;
    pdfTable.AddCell(cell);
