    public void shrink(PdfStamper stamper, int page, float factor)
    {
        Rectangle crop = stamper.Reader.GetCropBox(page);
        float diffX = crop.Right * (1 - factor);
        float diffY = crop.Top * (1 - factor);
        PdfDictionary pageN = stamper.Reader.GetPageN(page);
        stamper.MarkUsed(pageN);
        PdfArray ar = null;
        PdfObject content = PdfReader.GetPdfObject(pageN.Get(PdfName.CONTENTS), pageN);
        if (content == null)
            return;
        if (content.IsArray())
        {
            ar = new PdfArray((PdfArray)content);
            pageN.Put(PdfName.CONTENTS, ar);
        }
        else if (content.IsStream())
        {
            ar = new PdfArray();
            ar.Add(pageN.Get(PdfName.CONTENTS));
            pageN.Put(PdfName.CONTENTS, ar);
        }
        else
            return;
        ByteBuffer out_p = new ByteBuffer();
        out_p.Append(factor).Append(" 0 0 ").Append(factor).Append(' ').Append(diffX).Append(' ').Append(diffY).Append(" cm ");
        PdfStream stream = new PdfStream(out_p.ToByteArray());
        ar.AddFirst(stamper.Writer.AddToBody(stream).IndirectReference);
        out_p.Reset(); 
    }
