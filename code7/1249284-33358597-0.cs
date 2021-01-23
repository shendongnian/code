    PdfPTable pdfpTable = new PdfPTable(2);
    
    // your code above
    
    pdfpTable.DefaultCell.Border = PdfPCell.NO_BORDER;
    PdfPCell cell = new PdfPCell(new Phrase("Referral Code: ", nameFont))
    {
        Border = PdfPCell.NO_BORDER,
        HorizontalAlignment = Element.ALIGN_RIGHT
    };
    pdfpTable.AddCell(cell);
    cell = new PdfPCell(vouchertable) { Border = PdfPCell.NO_BORDER };
    pdfpTable.AddCell(cell);
