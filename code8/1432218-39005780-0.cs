    Bitmap original = new Bitmap(@"C:\image.png");
    Bitmap clone = new Bitmap(original.Width, original.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
    using (Graphics gr = Graphics.FromImage(clone)) {
        gr.DrawImage(original, new Rectangle(0, 0, clone.Width, clone.Height));
    }
