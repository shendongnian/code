    using (Graphics g = Graphics.FromImage(image))
    {
    	g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
    
    	foreach (var child in canvas.Children)
    	{
    		if (child is System.Windows.Shapes.Rectangle)
    		{
    			var oldRect = child as System.Windows.Shapes.Rectangle;
    
    			// need to do something here to make the new rect bigger as the scale is clearly different
    			var rect = new Rectangle((int)Canvas.GetLeft(oldRect), (int)Canvas.GetTop(oldRect), (int)oldRect.Width, (int)oldRect.Height);
    			g.FillRectangle(Brushes.Black, rect);
    		}
    	}
    	RenderTargetBitmap bmp = new RenderTargetBitmap((int)Canvas1.Width, (int)Canvas1.Height, 96, 96, PixelFormats.Default);
    	bmp.Render(Canvas1);
    }
