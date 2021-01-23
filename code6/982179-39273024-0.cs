    //Crops an image to even width and height
    public UIImage CenterCrop(UIImage)
    {
    	// Use smallest side length as crop square length
    	double squareLength = Math.Min(originalImage.Size.Width, originalImage.Size.Height);
    
    	nfloat x, y;
    	x = (nfloat)((originalImage.Size.Width - squareLength) / 2.0);
    	y = (nfloat)((originalImage.Size.Height - squareLength) / 2.0);
    
    	//This Rect defines the coordinates to be used for the crop
    	CGRect croppedRect = CGRect.FromLTRB(x, y, x + (nfloat)squareLength, y + (nfloat)squareLength);
    
    	// Center-Crop the image
    	UIGraphics.BeginImageContextWithOptions(croppedRect.Size, false, originalImage.CurrentScale);
    	originalImage.Draw(new CGPoint(-croppedRect.X, -croppedRect.Y));
    	UIImage croppedImage = UIGraphics.GetImageFromCurrentImageContext();
    	UIGraphics.EndImageContext();
    	
    	return croppedImage;
    }
