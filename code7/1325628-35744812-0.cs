    // ObjectDisposedException: Cannot access a closed Stream.
    using (var stream = new MemoryStream())
    {
        using (var document = new Document())
        {
            using (var writer = PdfWriter.GetInstance(document, stream))
            {
                document.Open();
                document.Add(new Chunk("test"));
            }
        }
        pdf = stream.ToArray();
    }
