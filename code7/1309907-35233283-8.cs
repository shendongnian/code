    string RemoveImage(string htmlToParse)
    {
        var hDocument = new HtmlDocument()
        {
            OptionWriteEmptyNodes = true,
            OptionAutoCloseOnEnd = true
        };
        hDocument.LoadHtml(htmlToParse);
        var root = hDocument.DocumentNode;
        var imagesDesktop = root.SelectNodes("//img[@class='img-desktop']"); 
        foreach (var image in imagesDesktop)
        {
            var imageText = image.NextSibling;
            imageText.Remove();
            image.Remove();
        }
        return root.WriteTo();
    }
