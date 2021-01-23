    using (var doc = WordprocessingDocument.Open("docx_path", false))
    {
        XNamespace wNs = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
        var xml = XElement.Parse(doc.MainDocumentPart.Document.InnerXml);
    
        var pageWidth = xml
            .Element(wNs + "sectPr")
            .Element(wNs + "pgSz")
            .Attribute(wNs + "w")
            .Value;
    }
