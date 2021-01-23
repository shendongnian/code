    var doc = new Document();
    PdfWriter.GetInstance(doc, new FileStream("C:/Doc1.pdf", FileMode.Create));
    doc.Open();
    PdfPTable table = new PdfPTable(1);
    PdfPCell cell1 = new PdfPCell(new Phrase("Cell1"));
    cell1.Colspan = 1;
    cell.PaddingRight = 20f; //Here you can set padding (Top, Bottom, Right, Left)
    table2.AddCell(cell1);
    PdfPCell cell2 = new PdfPCell(new Phrase("Cell2"));
    cell2.Colspan = 1;
    table2.AddCell(cell2);
    doc.Add(table);
    System.Diagnostics.Process.Start("C:/Doc1.pdf");
