    byte[] data;
    using (var sr = new StringReader(sw.ToString()))
    {
        var st = new StyleSheet();
        GetStyleSheetForUnicodeCharacters(st);
        using (var ms = new MemoryStream())
        {
            using (var pdfDoc = new Document())
            {                            
                using (var w = PdfWriter.GetInstance(pdfDoc, ms))
                {
                   pdfDoc.Open();
                   pdfDoc.NewPage(); // add Page here
                   var parsedHtmlElements = HTMLWorker.ParseToList(sr, st);
                   foreach (var htmlElement in parsedHtmlElements)
                   {
                      pdfDoc.Add(htmlElement as IElement);
                   }
                   pdfDoc.Close();
                   data = ms.ToArray();
                }
            }
        }
    }
