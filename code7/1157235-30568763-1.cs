    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
    var g = Graphics.FromImage(bitmap);
    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
    g.DrawString("AMBULANCE", font, brush, pictureBox.DisplayRectangle);
    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
    pictureBox.Image = bitmap; // display bitmap on your form
