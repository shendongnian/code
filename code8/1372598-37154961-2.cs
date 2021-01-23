    public static void Convert(string documentFileName, string htmlText)
    {
        HtmlLoadOptions options = LoadOptions.HtmlDefault;
        using (var htmlStream = new MemoryStream(options.Encoding.GetBytes(htmlText)))
            DocumentModel.Load(htmlStream, options)
                         .Save(documentFileName);
    }
