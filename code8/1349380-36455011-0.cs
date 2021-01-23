	/// <summary>
	/// Add a new page to the document
	/// </summary>
	public void NewPage() {
		// Add a new page to the page collection and set it as the current page
		Bitmap bmp;
		using(Graphics g = PrinterSettings.CreateMeasurementGraphics()) {
			int w=(Int32)( CurrentPaperSize.Width*g.DpiX )-(Int32)( ( ( DefaultPageSettings.Margins.Left+DefaultPageSettings.Margins.Right )/100 )*g.DpiX );
			int h=(Int32)( CurrentPaperSize.Height*g.DpiY )-(Int32)( ( ( DefaultPageSettings.Margins.Top+DefaultPageSettings.Margins.Bottom )/100 )*g.DpiY );
			bmp = new Bitmap( w, h );
			bmp.SetResolution(g.DpiX, g.DpiY);
		}
		// reset X and Y positions
		Y=0;
		X=0;
		// Add new page to the collection
		Pages.Add( bmp );
		CurrentPage++;
	}
