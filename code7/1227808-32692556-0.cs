    public ActionResult Index()
    {
        HttpContext.Response.Clear();
        HttpContext.Response.ContentType = "application/PDF";
        HttpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=" + "MyDoc.pdf");
        var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
        MemoryStream outputStream = new MemoryStream();
        using (Document doc = new Document())
        {
            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, new StreamReader(Server.MapPath("HTMLtoPDF.aspx")));
            // Works as well with passing example_html as below:
            // XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, new StringReader(example_html));
        }
        return View();
    }
 
