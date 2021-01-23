    int width = 80;
    int height = 80;
    using (Bitmap bitmap = new Bitmap(width, height))
    {
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            var font = new Font("MS Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Point);
            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            graphics.DrawString("012345", font, Brushes.Black, 0, 0);
        }
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.DrawImage(bitmap, ClientRectangle, 0, 0, width, height, GraphicsUnit.Pixel);
    }
