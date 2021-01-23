    using (PdfReader reader = new PdfReader(source))
    using (PdfStamper stamper = new PdfStamper(reader, new FileStream(dest, FileMode.Create, FileAccess.Write)))
    {
        for (int iCount = 0; iCount < reader.NumberOfPages; iCount++)
        {
            Rectangle PageSize = reader.GetCropBox(iCount + 1);
            PdfContentByte PDFData = stamper.GetOverContent(iCount + 1);
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
            Stamp(PDFData, PageSize, baseFont, "SAMPLE DOCUMENT");
        }
    }
