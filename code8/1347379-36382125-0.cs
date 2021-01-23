    var ms = new MemoryStream();
    using (var doc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25))
    {
        using (var writer = PdfWriter.GetInstance(doc, ms))
        {
            doc.Open();
            // adding content
            var bytes = ms.ToArray();
            doc.Close();
            // write bytes to a file.
        }
    }
