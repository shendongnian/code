    using (var document = new PdfDocument())
    {
        var page = document.AddPage();
        var graphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);
        graphics.SmoothingMode = XSmoothingMode.HighQuality;
    
        var bounds = new XRect(graphics.PageOrigin, graphics.PageSize);
        var state = graphics.Save();
        graphics.DrawRectangle(
            new XLinearGradientBrush(
                bounds,
                XColor.FromKnownColor(XKnownColor.Red),
                XColor.FromKnownColor(XKnownColor.White),
                XLinearGradientMode.ForwardDiagonal),
            bounds);
        graphics.Restore(state);
        graphics.DrawString(
            "Hello World!",
            new XFont("Arial", 20),
            XBrushes.Black,
            bounds.Center,
            XStringFormats.Center);
    
        document.Save("test.pdf");
        document.Close();
    }
