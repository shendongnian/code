    for (int page = 1; page <= _rasterizer.PageCount; page++)
    {
        var docName = String.Format("Page-{0}.pdf", page);
        var pageFilePath = Path.Combine(outputPath, docName);
        var pdf = _rasterizer.GetPage(desired_x_dpi, desired_y_dpi, pageNumber);
        pdf.Save(pageFilePath, ImageFormat.Pdf);
        pagesAsImages.Add(pdf);
    }
