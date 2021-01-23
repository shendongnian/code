    public static void CreateDocument(string documentFileName, string text)
    {
        DocumentModel document = DocumentModel.Load(documentFileName, LoadOptions.DocxDefault);
    
        document.Content.Find("#REPLACE#").First().LoadText(text, LoadOptions.HtmlDefault);
    
        document.Save(documentFileName, SaveOptions.DocxDefault);
    }
