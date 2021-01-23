    var imageWidth = 640; // read value from image metadata stream part
    var imageHeight = 480 // same as for width
    var bytes = stream.Read(..) // array length must be width * height
    
    using (var image = new Bitmap(imageWidth, imageHeight))
    {
    	var bitmapData = image.LockBits(new Rectangle(0, 0, imageWidth, imageHeight),
    		System.Drawing.Imaging.ImageLockMode.ReadWrite, // r/w memory access
    		image.PixelFormat); // possibly you should read it from stream 
    
    	// copying
    	System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bitmapData.Scan0, bitmapData.Height * bitmapData.Stride);
    	image.UnlockBits(bitmapData);
    
    	// do your work with bitmap
    }
