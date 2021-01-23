    Document doc = new Document();
    PdfWriter writer =
      PdfWriter.GetInstance(doc, new FileStream("tables.pdf", FileMode.Create));
    doc.Open();
    doc.Add(new Paragraph("Table without rowspan:"));
    PdfPTable table = new PdfPTable(3);
    table.SpacingBefore = 10;
    table.AddCell(new PdfPCell(new Phrase("1,1")));
    table.AddCell(new PdfPCell(new Phrase("1,2")));
    table.AddCell(new PdfPCell(new Phrase("1,3")));
    table.AddCell(new PdfPCell(new Phrase("2,1")));
    table.AddCell(new PdfPCell(new Phrase("2,2")));
    table.AddCell(new PdfPCell(new Phrase("2,3")));
    table.AddCell(new PdfPCell(new Phrase("3,1")));
    table.AddCell(new PdfPCell(new Phrase("3,2")));
    table.AddCell(new PdfPCell(new Phrase("3,3")));
    doc.Add(table);
    doc.Add(new Paragraph("Table with rowspan 3 on first cell:"));
    PdfPTable tableWithRowspan = new PdfPTable(3);
    tableWithRowspan.SpacingBefore = 10;
    PdfPCell cellWithRowspan = new PdfPCell(new Phrase("1,1"));
    // The first cell spans 3 rows
    cellWithRowspan.Rowspan = 3;
    tableWithRowspan.AddCell(cellWithRowspan);
    tableWithRowspan.AddCell(new PdfPCell(new Phrase("1,2")));
    tableWithRowspan.AddCell(new PdfPCell(new Phrase("1,3")));
    // Cell 2,1 does not exist
    tableWithRowspan.AddCell(new PdfPCell(new Phrase("2,2")));
    tableWithRowspan.AddCell(new PdfPCell(new Phrase("2,3")));
    // Cell 3,1 does not exist
    tableWithRowspan.AddCell(new PdfPCell(new Phrase("3,2")));
    tableWithRowspan.AddCell(new PdfPCell(new Phrase("3,3")));
    doc.Add(tableWithRowspan);
    doc.Close();
