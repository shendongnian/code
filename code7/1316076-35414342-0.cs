    HtmlDocument document = new HtmlDocument();
    //your html stream
    document.Load(stream);
    var container = document.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "div3Class");
    if (container != null)
    {
        var image = container.Descendants("img").FirstOrDefault(x => x.Attributes.Contains("src"));
        if (image != null)
        {
            var imageSrcValue = image.Attributes["src"].Value;
        }
        var subjectItem = container.Descendants("h3").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "subject");
        if (subjectItem != null)
        {
            var subjectItemValue = subjectItem.InnerText;
        }
    }
