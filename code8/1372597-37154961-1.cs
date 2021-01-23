    public static void CreateDocument(string documentFileName, string text)
    {
        DocumentModel document = new DocumentModel();
        document.Content.LoadText(text, LoadOptions.HtmlDefault);
        document.Save(documentFileName);
    }
