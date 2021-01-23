    int width = 100;
    int height = 50;
    using (Bitmap bitmap = new Bitmap(width, height))
    {
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            var font = new Font("MS Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point);
            graphics.DrawString("012345", font, Brushes.Black, 0, 0);
        }
        e.Graphics.DrawImage(bitmap, ClientRectangle, 0, 0, width, height, GraphicsUnit.Pixel);
    }
