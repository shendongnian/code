    private byte[] CreatePdf()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (Document document = new Document())
            {
                PdfWriter.GetInstance(document, ms);
                document.Open();
                document.Add(new Paragraph("Hello World"));
            }
            return ms.ToArray();
        }
    }
