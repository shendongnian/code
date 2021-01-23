    String tempDir = Path.GetTempFileName();
    File.Delete(tempDir);
    Directory.CreateDirectory(tempDir);
    tempDir = Utils.addBackslash(tempDir);
    ExportToPNG(tempDir);
    String imageFile = Utils.FindFirstFile(tempDir, "*.png");
    if (imageFile != "")
    {
    	PrintDocument pd = new PrintDocument();
    	try
    	{
    		pd.DefaultPageSettings.PrinterSettings.PrinterName = DB.Instance.getSetting("label.printername");
    	}
    	catch
    	{
    		// This is just a preset, it may fail without consequences
    	}
    
    	pd.DefaultPageSettings.Landscape = false; // Now I can do it!
    	pd.PrintPage += (sender, args) =>
    	{
    		Image i = Image.FromFile(imageFile);
    		Point p = new Point(100, 100);
    		args.Graphics.DrawImage(i, 0, 0, i.Width, i.Height);
    	};
    	PrintDialog pdi = new PrintDialog();
    	pdi.Document = pd;
    	if (pdi.ShowDialog() == DialogResult.OK)
    		pd.Print();
    	pd.Dispose();
    }
