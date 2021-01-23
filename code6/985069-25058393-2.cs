    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(documentStream, true))
    {
        MainDocumentPart mainPart = wordDocument.MainDocumentPart;
        Body body = wordDocument.MainDocumentPart.Document.Body;
        Paragraph para = body.AppendChild(new Paragraph());
        Paragraph para2 = body.AppendChild(new Paragraph());
        Paragraph para3 = body.AppendChild(new Paragraph());
        StyleDefinitionsPart part = wordDocument.MainDocumentPart.StyleDefinitionsPart;
        if (part != null)
        {
            //I'm looping the styles and adding them here
            //you could clone the whole StyleDefinitionsPart
            //but then you'd lose custom styles in your source doc
            using (WordprocessingDocument wordTemplate = WordprocessingDocument.Open(@"C:\Program Files\Microsoft Office\Office14\1033\QuickStyles\default.dotx", false))
            {
                foreach (var templateStyle in wordTemplate.MainDocumentPart.StyleDefinitionsPart.Styles)
                {
                    part.Styles.Append(templateStyle.CloneNode(true));
                }
            }
            //I can now use any built in style 
            //I'm using Heading1, Title and IntenseQuote as examples
            //You may need to do a language conversion here as 
            //you mentione your docx is in Dutch
            ParagraphProperties pPr = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Heading1" };
            pPr.Append(paragraphStyleId1);
            para.Append(pPr);
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text("This is a heading"));
            ParagraphProperties pPr2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Title" };
            pPr2.Append(paragraphStyleId2);
            para2.Append(pPr2);
            Run run2 = para2.AppendChild(new Run());
            run2.AppendChild(new Text("This is a title"));
            ParagraphProperties pPr3 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId3 = new ParagraphStyleId() { Val = "IntenseQuote" };
            pPr3.Append(paragraphStyleId3);
            para3.Append(pPr3);
            Run run3 = para3.AppendChild(new Run());
            run3.AppendChild(new Text("This is an intense quote"));
        }
    }
