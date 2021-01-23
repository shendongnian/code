    using System.Drawing;
    using System.Drawing.Imaging;
    Bitmap originalBmp;
    var converted = new Bitmap(originalBmp.Width, originalBmp.Height, PixelFormat.Format32bppPArgb);
    using (var g = Graphics.FromImage(converted))
    {
    	g.DrawImage(0, 0, originalBmp);
    }
