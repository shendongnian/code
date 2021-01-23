    using RazorEngine;
    using RazorEngine.Templating;
    ...
    string razorText = System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/Views/MyReport.cshtml"));
    string body = Razor.Parse(razorText, model);
    byte[] pdfBinary = MyFramework.PDFHelper.GetPDFGromHTMLString(body);
    /**other stuff */
