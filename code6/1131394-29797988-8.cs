    private void HueRotateButton_Click(object sender, EventArgs e)
    {
        // Get the cosine and sine of the selected hue rotation angle
        var radians = Math.PI * (double)HueRotateAngleSelector.Value / 180.0;
        var cos = (float)Math.Cos(radians);
        var sin = (float)Math.Sin(radians);
        // Create an image attributes object from a hue rotation color matrix
        var colorMatrix =
            new ColorMatrix(
                new[]
                    {
                        new[] { 0.213f + cos * 0.787f - sin * 0.213f, 0.213f - cos * 0.213f + sin * 0.143f, 0.213f - cos * 0.213f - sin * 0.787f, 0f, 0f }, 
                        new[] { 0.715f - cos * 0.715f - sin * 0.715f, 0.715f + cos * 0.285f + sin * 0.140f, 0.715f - cos * 0.715f + sin * 0.715f, 0f, 0f },
                        new[] { 0.072f - cos * 0.072f + sin * 0.928f, 0.072f - cos * 0.072f - sin * 0.283f, 0.072f + cos * 0.928f + sin * 0.072f, 0f, 0f }, 
                        new[] { 0f, 0f, 0f, 1f, 0f }, 
                        new[] { 0f, 0f, 0f, 0f, 1f }
                    });
        var imageAttributes = new ImageAttributes();
        imageAttributes.SetColorMatrix(colorMatrix);
        // Get the current image from the picture box control
        var bitmap = (Bitmap)HueRotatePictureBox.Image;
        var width = bitmap.Width;
        var height = bitmap.Height;
        // Get a graphics object of the bitmap and draw the hue rotation
        // transformed image on the bitmap area
        var graphics = Graphics.FromImage(bitmap);
        graphics.DrawImage(
            bitmap,
            new Rectangle(0, 0, width, height),
            0,
            0,
            width,
            height,
            GraphicsUnit.Pixel,
            imageAttributes);
        // Update the image in the picutre box
        HueRotatePictureBox.Image = bitmap;
    }
