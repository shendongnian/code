    using (var reader = new PdfReader("Source.Pdf")) {
        using (var fileStream = new FileStream("Dest.Pdf"), FileMode.Create, FileAccess.Write) {
            using (PdfStamper stamper = new PdfStamper(reader, fileStream)) {
                //Get a PdfContentByte object
                var cb = stamper.GetOverContent(reader.NumberOfPages);
                //Create a ColumnText object
                var ct = new ColumnText(cb);
                //Set the rectangle to write to
                ct.SetSimpleColumn(100, 30, 500, 90, 0, PdfContentByte.ALIGN_LEFT);
                //Add some text and make it blue so that it looks like a hyperlink
                var c = new Chunk("Click here!", linkFont);
                var congrats = new Paragraph("Congratulations on reading the eBook!    ");
                congrats.Alignment = PdfContentByte.ALIGN_LEFT;
                c.SetAnchor("http://www.domain.com/pdf/response/" + encryptedId);
                //Add the chunk to the ColumnText
                congrats.Add(c);
                ct.AddElement(congrats);
                //Tell the system to process the above commands
                ct.Go();
            }
        }
    }
