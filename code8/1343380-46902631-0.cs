    table.AddCell(new PdfPCell(new Phrase("Sr No")) { Rowspan = 2, BackgroundColor = BaseColor.GRAY });
    PdfPCell CellZero1 = table.AddCell(new PdfPCell(new Phrase("Name")) { Rowspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.GRAY });
    CellZero1.VerticalAlignment = Element.ALIGN_CENTER;
    table.AddCell(new PdfPCell(new Phrase("Phone")) { Rowspan = 2, BackgroundColor = BaseColor.GRAY });
    PdfPTable nestedTable = new PdfPTable(2);
    PdfPCell cell1 = new PdfPCell(new Phrase("12") );
    PdfPCell cell2 = new PdfPCell();
    PdfPCell cell3 = new PdfPCell(new Phrase("545445444"));
    nestedTable.AddCell(new PdfPCell(new Phrase("First Name")){ BackgroundColor = BaseColor.GRAY });
    nestedTable.AddCell(new PdfPCell(new Phrase("Last Name")) { BackgroundColor = BaseColor.GRAY });
  
    for (int i = 1; i < 6; i++)
    {
        nestedTable.AddCell(new PdfPCell(new Phrase("data" + i)) );
        nestedTable.AddCell(new PdfPCell(new Phrase("last" + i)) );
    }
    cell2.AddElement(nestedTable);
    table.AddCell(cell1);
    table.AddCell(cell2);
    table.AddCell(cell3);
    doc.Add(table);
