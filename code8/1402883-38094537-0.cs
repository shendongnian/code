    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.tool.xml;
    
    
    byte[] pdf; // result will be here
    
    var cssText = File.ReadAllText(MapPath("~/css/style.css"));
    var html = File.ReadAllText(MapPath("~/css/index.html"));
    
    using (var memoryStream = new MemoryStream())
    {
            var document = new Document(PageSize.A4, 20, 20, 30, 30);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
    
            using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
            {
                using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream);
                }
            }
    
            document.Close();
    
            pdf = memoryStream.ToArray();
    }
