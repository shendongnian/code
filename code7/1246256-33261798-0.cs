    public PdfArray GetId(string FileName)
    {
        using (PdfReader pdfReader = new PdfReader(FileName))
        {
            return pdfReader.Trailer.GetAsArray(PdfName.ID);
        }
    }
