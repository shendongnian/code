    [Test]
    public void ResetStreamPositionAtEndOfUsing()
    {
        string outputFilePath = @"test-results\misc\resetStreamPosition.pdf";
        Directory.CreateDirectory(@"test-results\misc\");
        MemoryStream output = new MemoryStream();
        Document document = new Document(PageSize.A4, 30, 30, 30, 30);
        PdfWriter writer = PdfWriter.GetInstance(document, output);
        using (output)
        {
            using (document)
            {
                document.Open();
                document.Add(new Paragraph("Test"));
                output.Position = 0;
            }
            Byte[] data = output.ToArray();
            File.WriteAllBytes(outputFilePath, data);
        }
    }
