    using Ghostscript.NET.Rasterizer;
    private void button6_Click(object sender, EventArgs e)
    {
        int desired_x_dpi = 96;
        int desired_y_dpi = 96;
        string inputPdfPath = @"D:\Public\temp\rasterizer\FOS.pdf";
        string outputPath = @"D:\Public\temp\rasterizer\output\";
        using (var rasterizer = new GhostscriptRasterizer())
        {
            rasterizer.Open(inputPdfPath);
            for (var pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
            {
                var pageFilePath = Path.Combine(outputPath, string.Format("Page-{0}.png", pageNumber));
                var img = rasterizer.GetPage(desired_x_dpi, desired_y_dpi, pageNumber);
                img.Save(pageFilePath + "ImageFormat.Png");
            }
        }
    }
