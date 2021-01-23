    private static void GhostscriptNetRaster(String fileName, String outputPath)
    {
        var version = Ghostscript.NET.GhostscriptVersionInfo.GetLastInstalledVersion();
        using (var rasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer())
        {
            rasterizer.Open(File.Open(fileName, FileMode.Open, FileAccess.Read), version, false);
            for (int page = 0; page < rasterizer.PageCount; page++)
            {
                var img = rasterizer.GetPage(96, 96, page);
                img.Save(outputPath);
            }
        }
    }
