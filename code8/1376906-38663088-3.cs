    [Test]
    public void testRemoveBigText()
    {
        string source = @"sid-1.pdf";
        string dest = @"sid-1-noBigText.pdf";
        using (PdfReader pdfReader = new PdfReader(source))
        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(dest, FileMode.Create, FileAccess.Write)))
        {
            PdfContentStreamEditor editor = new BigTextRemover();
            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                editor.EditPage(pdfStamper, i);
            }
        }
    }
