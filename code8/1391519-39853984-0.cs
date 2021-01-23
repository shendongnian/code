    Document pdfDoc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
    pdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(image);
    img.SetAbsolutePosition(0, 0);
    img.ScaleAbsoluteHeight(pdfDoc.PageSize.Height);
    img.ScaleAbsoluteWidth(pdfDoc.PageSize.Width);
