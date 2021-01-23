    private string GetDocumentContents(HttpRequestBase Request)
    {
        string documentContents;
        using (Stream receiveStream = Request.InputStream)
        {
            using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
            {
                documentContents = readStream.ReadToEnd();
            }
        }
        return documentContents;
    }
