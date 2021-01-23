    /// <summary>
    /// Creates a Thumbnail of the Bitmap.
    /// </summary>
    /// <param name="sourceBitmap">Source Bitmap.</param>
    /// <param name="width">Width for the Tumbnail.</param>
    /// <param name="height">Height for the Tumbnail.</param>
    /// <returns>Returns the created Thumbnail.</returns>
    [Extension()]
    public Bitmap CreateThumbnail(this Bitmap sourceBitmap, Int32 width, Int32 height)
    {
    	if (sourceBitmap == null) {
    		return null; // Eat Exception !
    	} else {
    		if ((width > 0) && (height > 0)) {
    			Rectangle layoutRectangle = new Rectangle(0, 0, width, height);
    			Bitmap thumbnailBitmap = new Bitmap(width, height, sourceBitmap.PixelFormat);
    
    			using (Graphics bmpGrphics = thumbnailBitmap.CreateGraphics()) {
    				bmpGrphics.DrawImage(sourceBitmap, layoutRectangle);
    			}
    
    			return thumbnailBitmap;
    		} else {
    			return null;
    		}
    	}
    }
