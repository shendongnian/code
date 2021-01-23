    PdfWriter writer = null;
    try
    {
        using (var stream = new MemoryStream())
        {
            using (var document = new Document())
            {
                writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                document.Add(new Chunk("test"));
            }
            pdf = stream.ToArray();
        }
    }
    finally { writer.Dispose(); }
