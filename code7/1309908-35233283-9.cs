    var parsedHtml = RemoveImage(HTML);
    using (var xmlSnippet = new StringReader(parsedHtml))
    {
        using (FileStream stream = new FileStream(
            outputFile,
            FileMode.Create,
            FileAccess.Write))
        {
            using (var document = new Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(
                    document, stream
                );
                document.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(
                    writer, document, xmlSnippet
                );
            }
        }
    }
