    private Bitmap currentBitmap;
    public void CaptureWindowToMemory(IntPtr handle, Action<Bitmap> action)
    {
    	using (var img = CaptureWindow(handle))
    	{
    		var newBitmap = new Bitmap(img);
    		newBitmap.Save("foo.png", System.Drawing.Imaging.ImageFormat.Png);
    
    		action(newBitmap);
    
    		if (currentBitmap != null)
    			currentBitmap.Dispose();
    
    		currentBitmap = newBitmap;
    	}
    }
