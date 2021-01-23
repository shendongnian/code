    // get the PDF file
    string pdfFile = Server.MapPath("~") + @"\DemoFiles\Pdf\InputPdf.pdf";
    
    // create the PDF rasterizer
    PdfRasterizer pdfRasterizer = new PdfRasterizer();
    
    // set the output images color space
    pdfRasterizer.ColorSpace = GetColorSpace();
    
    // set the rasterization resolution in DPI
    pdfRasterizer.DPI = int.Parse(textBoxDPI.Text);
    
    int fromPdfPageNumber = int.Parse(textBoxFromPage.Text);
    int toPdfPageNumber = textBoxToPage.Text.Length > 0 ? int.Parse(textBoxToPage.Text) : 0;
    
    // rasterize a range of pages of the PDF document to memory in .NET Image objects
    // the images can also be produced to a folder using the RasterizeToImageFiles method
    // or they can be produced one by one using the RaisePageRasterizedEvent method
    PdfPageRasterImage[] pageImages = pdfRasterizer.RasterizeToImageObjects(pdfFile, fromPdfPageNumber, toPdfPageNumber);
    
    // return if no page was rasterized
    if (pageImages.Length == 0)
        return;
    
    // get the first page image bytes in a buffer
    byte[] imageBuffer = null;
    try
    {
        // get the .NET Image object
        System.Drawing.Image imageObject = pageImages[0].ImageObject;
    
        // get the image data in a buffer
        imageBuffer = GetImageBuffer(imageObject);
    }
    finally
    {
        // dispose the page images
        for (int i = 0; i < pageImages.Length; i++)
            pageImages[i].Dispose();
    }
    
    // inform the browser about the binary data format
    HttpContext.Current.Response.AddHeader("Content-Type", "image/png");
    
    // let the browser know how to open the image and the image name
    HttpContext.Current.Response.AddHeader("Content-Disposition",
                String.Format("attachment; filename={0}; size={1}", "PageImage", imageBuffer.Length.ToString()));
    
    // write the image buffer to HTTP response
    HttpContext.Current.Response.BinaryWrite(imageBuffer);
    
    // call End() method of HTTP response to stop ASP.NET page processing
    HttpContext.Current.Response.End();
