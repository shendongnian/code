    public static byte[] resizeProportionaly(byte[] imageFile, int pWidth, int pHeight, string crop = "&crop=auto")
        {
        	MemoryStream stream = new MemoryStream(imageFile);
        	stream.Seek(0, SeekOrigin.Begin);
        	ResizeSettings resizeCropSettings = new ResizeSettings(string.Format("bgcolor=FFFFFF&width={0}&height={1}&format=jpg" + crop, pWidth, pHeight));
        	Image originalImage = Image.FromStream(stream, true, false);
        
        
        	Image resizedImage = ImageBuilder.Current.Build(originalImage, resizeCropSettings);
        	MemoryStream ms = new MemoryStream();
        	resizedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        	return ms.ToArray();
        }
    
