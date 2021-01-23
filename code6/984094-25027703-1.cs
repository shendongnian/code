    string sDLLPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
    	"gsdll32.dll");
    GhostscriptVersionInfo gvi = new GhostscriptVersionInfo(sDLLPath);
    using (GhostscriptRasterizer rasterizer = new GhostscriptRasterizer())
    {
    	rasterizer.Open("sample.pdf", gvi, false);
    
    	int dpi_x = 96;
    	int dpi_y = 96;
    	for (int i = 1; i <= rasterizer.PageCount; i++)
    	{
    		Image img = rasterizer.GetPage(dpi_x, dpi_y, i);
    		// System.Drawing.Image obtained. Now it can be used at will.
    		// Simply save it to storage as an example.
    		img.Save(Path.Combine("C:\\Temp", "page_" + i + ".png")),
    			System.Drawing.Imaging.ImageFormat.Png);
    	}
    }
