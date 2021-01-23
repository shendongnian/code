    public void PrintPdf(string filePath, string printQueueName, PaperSource paperTray)
    {
    	using (ManualResetEvent done = new ManualResetEvent(false))
    	using (PrintDocument document = new PrintDocument())
    	{
    		document.DocumentName = "My PDF";
    		document.PrinterSettings.PrinterName = printQueueName;
    		document.DefaultPageSettings.PaperSize = new PaperSize("Letter", 850, 1100);
    		document.DefaultPageSettings.PaperSource = paperTray;
    		document.OriginAtMargins = false;
    
    		using (var rasterizer = new GhostscriptRasterizer())
    		{
    			var lastInstalledVersion =
    				GhostscriptVersionInfo.GetLastInstalledVersion(
    						GhostscriptLicense.GPL | GhostscriptLicense.AFPL,
    						GhostscriptLicense.GPL);
    
    			rasterizer.Open(filePath, lastInstalledVersion, false);
    
    			int xDpi = 96, yDpi = 96, pageNumber = 0;
    
    			document.PrintPage += (o, p) =>
    			{
    				pageNumber++;
    				p.Graphics.DrawImageUnscaledAndClipped(
    					rasterizer.GetPage(xDpi, yDpi, pageNumber),
    					new Rectangle(0, 0, 850, 1100));
    				p.HasMorePages = pageNumber < rasterizer.PageCount;
    			};
    
    			document.EndPrint += (o, p) =>
    			{
    				done.Set();
    			};
    
    			document.Print();
    			done.WaitOne();
    		}
    	}
    }
