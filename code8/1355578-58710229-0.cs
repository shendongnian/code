    var license = new Aspose.Pdf.License();
    license.SetLicense("Aspose.Pdf.lic");
    var license = new Aspose.Html.License();
    license.SetLicense("Aspose.Html.lic");
    using (MemoryStream memoryStream = new MemoryStream())
    {
          var options = new PdfRenderingOptions();
          using (PdfDevice pdfDevice = new PdfDevice(options, memoryStream))
          {
              using (var renderer = new HtmlRenderer())
              {
                  using (HTMLDocument htmlDocument = new HTMLDocument(content, ""))
                  {
                       renderer.Render(pdfDevice, htmlDocument);
                       //Save memoryStream into output pdf file
                  }
               }
           }
     }
