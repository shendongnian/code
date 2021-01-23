    private static RenderTargetBitmap ConvertToBitmap(UIElement uiElement, double resolution)
        {
        	dynamic scale = resolution / 96.0;
        	uiElement.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
        	dynamic sz = uiElement.DesiredSize;
        	dynamic rect = new Rect(sz);
        	uiElement.Arrange(rect);
        	dynamic bmp = new RenderTargetBitmap(Convert.ToInt32(scale * (rect.Width)), Convert.ToInt32(scale * (rect.Height)), scale * 96, scale * 96, PixelFormats.Default);
        	bmp.Render(uiElement);
        	return bmp;
        }
