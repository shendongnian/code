    byte[] docByteArray = File.ReadAllBytes("testDoc.docx");
    using (MemoryStream memoryStream = new MemoryStream())
    {
        memoryStream.Write(docByteArray, 0, docByteArray.Length);
        using (WordprocessingDocument doc =
        WordprocessingDocument.Open(memoryStream, true))
        {
            var body = doc.MainDocumentPart.Document.Body;
            var paragraphs = new List<Paragraph>();
    
            foreach(Paragraph paragraph in body.Descendants<Paragraph>()
                .Where(e => e.ParagraphProperties != null))
            {
                if(paragraph.ParagraphProperties.ParagraphMarkRunProperties != null)
                {
                    foreach(OpenXmlElement element in paragraph.ParagraphProperties.ParagraphMarkRunProperties.ChildElements)
                    {
                        Console.WriteLine(element.OuterXml);
                    }
                }
       
                Console.WriteLine(paragraph.InnerText);
                }
            }
        }
    }
