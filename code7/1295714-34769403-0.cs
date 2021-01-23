    //Create our base font and actual font
    var baseFont = BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    var mainFont = new iTextSharp.text.Font(baseFont, 10);
    //Our Phrase will hold all of our chunks
    var p = new Phrase();
    //Add the start text
    p.Add(new Chunk("Request for grant of leave for ", mainFont));
    //Add our underlined text
    var c = new Chunk("2", mainFont);
    c.SetUnderline(0.1f, -1f);
    p.Add(c);
    //Add our end text
    p.Add(new Chunk(" days", mainFont));
    //Draw our formatted text
    ColumnText.ShowTextAligned(pdfWriter.DirectContent, PdfContentByte.ALIGN_LEFT, p, 100, 540, 0);
