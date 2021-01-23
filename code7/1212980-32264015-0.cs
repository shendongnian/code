    private Bitmap CreateImageFromText(string Text)
    {
           // Create the Font object for the image text drawing.
            Font textFont = new Font("Arial", 25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
    
            Bitmap ImageObject = new Bitmap(30, 30);
            // Add the anti aliasing or color settings.
            Graphics GraphicsObject = Graphics.FromImage(ImageObject);
     
            // Set Background color
            GraphicsObject.Clear(Color.White);
            // to specify no aliasing
            GraphicsObject.SmoothingMode = SmoothingMode.Default;
            GraphicsObject.TextRenderingHint = TextRenderingHint.SystemDefault;
            GraphicsObject.DrawString(Text, textFont, new SolidBrush(Color.Brown), 0, 0);
            GraphicsObject.Flush();
           return (ImageObject);
      }
