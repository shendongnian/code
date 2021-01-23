    var ms = new MemoryStream();
    using (var doc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25))
    {
        PdfWriter.GetInstance(doc, ms));
        doc.Open();
        // adding content
    }
    var bytes = ms.ToArray();
    // write bytes to a file
