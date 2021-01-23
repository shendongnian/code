    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    
        if(img == null)
        {
            ImageMovie1.Image = null;
        }
        else
        {
            MemoryStream ms = new MemoryStream(img);
            Bitmap GraphicFile = Image.FromStream(ms)
            // then if you need to modify the image at all you can create a graphics object
            // Graphics drawing = Graphics.FromImage(GraphicFile);
        }
