    protected void ProcessHtml(object sender, CommandEventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=table.pdf");
        using (Document document = new Document())
        {
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
    
            var html = new StringBuilder();
            using (var stringWriter = new StringWriter(html))
            {
                using (var htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    // replace with GridView control Id!
                    ConvertControlToPdf.RenderControl(htmlWriter);
                }
            }
    
            var providers = new Dictionary<string, Object>();
            // HTMLWorker does **NOT** understand relative URLs, so
            // make existing ones in HTML source absolute, and handle 
            // base64 Data URI schemes
            var ih = new ImageHander() { BaseUri = Request.Url.ToString() };
    
            // dictionary key 'img_provider' is **HARD-CODED**, in 
            // iTextSharp 5.0.0 - 5.0.5, so you may need to use this
            // interfaceProps.Add("img_provider", ih);
            providers.Add(HTMLWorker.IMG_PROVIDER, ih);
            //            ^^^^^^^^^^^^^^^^^^^^^^^ - constant added in 5.0.6
            using (var sr = new StringReader(html.ToString()))
            {
                foreach (IElement element in HTMLWorker.ParseToList(
                    sr, null, providers))
                {
                    PdfPTable table = element as PdfPTable;
                    document.Add(element);
                }
            }
        }
        Response.End();
    }
