    public ActionResult Index()
    {
        HttpContext.Response.Clear();
        HttpContext.Response.ContentType = "application/PDF";
        HttpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=" + "MyDoc.pdf");
        var page1 = @"<p>PAGE 1 This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
        var page2 = @"<p>PAGE 2 This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
        var page3 = @"<p>PAGE 3 This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
        MemoryStream outputStream = new MemoryStream();
        using (Document doc = new Document())
        {
            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();
            
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, new StringReader(page1));
            // To add more pages you can call NewPage and add other HTML snippets
            doc.NewPage();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, new StringReader(page2));
            doc.NewPage();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, new StringReader(page3));
        }
        return View();
    }
 
