    string fileName = @"MyTemplate";
    using (WordprocessingDocument pkgDoc = WordprocessingDocument.Open(fileName, true))
    {
        pkgDoc.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
        var test = (pkgDoc.MainDocumentPart.RootElement.InnerXml);
    string filenamecible = @"@MyNewWordDocument";
    using (WordprocessingDocument package = WordprocessingDocument.Create(filenamecible, WordprocessingDocumentType.Document))
    {
        MainDocumentPart mainPart = package.AddMainDocumentPart();
        //Create DOM tree for simple document. 
        mainPart.Document = new Document();
        for (int i = 0; i < csvline.Count; i++)
        {
             var x = new Break() { Type = BreakValues.Page };
             Body b = new Body(test);
             mainPart.Document.Append(b);
             mainPart.Document.Append(x);
             mainPart.Document.Save();
        }
        package.MainDocumentPart.Document.Save();
    }
    }
