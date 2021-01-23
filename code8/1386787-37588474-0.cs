    public Stream SignDocument(Stream requestStream)
    {
        string originalFileName = Path.GetTempFileName();
        string signedFileName = Path.GetTempFileName();
        using (var originalFileStream = File.Open(originalFileName, FileMode.Create, FileAccess.Write))
        {
            requestStream.CopyTo(originalFileStream);
        }
        XmlDocumentSigner.SignFile(originalFileName, signedFileName);
        var ms = new MemoryStream(File.ReadAllBytes(signedFileName));
        File.Delete(signedFileName);
        return ms;
    }
