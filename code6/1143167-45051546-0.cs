        [Route("Export/ExportToPdf")]
        public byte[] ExportToPdf(string html)
        {           
            MemoryStream msOutput = new MemoryStream();
            TextReader reader = new StringReader(html);
            Document document = new Document(new Rectangle(842, 595));             
            PdfWriter writer = PdfWriter.GetInstance(document, msOutput);
            document.Open();
            document.HtmlStyleClass = @"<style>*{ font-size: 8pt; font-family:arial;}</style>";
            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(html), null);
            foreach (var htmlElement in parsedHtmlElements)
            {
                document.Add(htmlElement as IElement);
            }
            document.Close();
            return msOutput.ToArray();
        }
