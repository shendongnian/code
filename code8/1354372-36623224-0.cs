    public static WordprocessingDocument InsertText(this WordprocessingDocument doc, string contentControlTag, string text)
    {
        SdtElement element = doc.MainDocumentPart.Document.Body.Descendants<SdtElement>()
          .FirstOrDefault(sdt => sdt.SdtProperties.GetFirstChild<Tag>()?.Val == contentControlTag);
        if (element == null)
          throw new ArgumentException($"ContentControlTag \"{contentControlTag}\" doesn't exist.");
        element.Descendants<Text>().First().Text = text;
        element.Descendants<Text>().Skip(1).ToList().ForEach(t => t.Remove());
        return doc;
    }
