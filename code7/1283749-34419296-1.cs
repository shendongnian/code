    [Test]
    public void ShrinkFirstPage()
    {
        string origFile = ...;
        string resultFile = ...;
        using (PdfReader reader = new PdfReader(origFile))
        using (FileStream output = new FileStream(resultFile, FileMode.Create, FileAccess.Write))
        using (PdfStamper stamper = new PdfStamper(reader, output))
        {
            int page = 1;
            float factor = .9f;
            shrink(stamper, page, factor);
            Rectangle box = reader.GetCropBox(page);
            box.Top = box.Top - factor * box.Height;
            PdfContentByte cb = stamper.GetOverContent(page);
            cb.SetColorFill(BaseColor.YELLOW);
            cb.SetColorStroke(BaseColor.RED);
            cb.Rectangle(box.Left, box.Bottom, box.Width, box.Height);
            cb.FillStroke();
            cb.SetColorFill(BaseColor.BLACK);
            ColumnText ct = new ColumnText(cb);
            ct.AddElement(new Paragraph("This is some text added to the front page of the front page of this document."));
            ct.SetSimpleColumn(box);
            ct.Go();
        }
    }
