    Bitmap image; 
    image = new Bitmap((Bitmap)baseImage.Clone());
    using (Graphics g = Graphics.FromImage(image) )
    {
       // I am drawing on the bitmap so I don't permanently change my base image
       // draw stuff here..
       // ..  
    }
    // don't leak the image and..
    // ..don't Dispose without checking for null
    if (paintBox.Image != null) paintBox.Image.Dispose()
    paintBox.Image = image;
