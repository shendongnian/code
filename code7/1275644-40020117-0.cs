    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
     
    ...
     
    public ActionResult Hello(string text)
    {
        //Create new image
        Image img = new Bitmap(100, 50);
        Graphics g = Graphics.FromImage(img);
                 
        //Do some drawing
        Font font = new Font("Arial", 24);
        PointF drawingPoint = new PointF(10, 10);
                 
        g.DrawString(text, font, Brushes.Black, drawingPoint);
     
        //Return Image
        MemoryStream ms = new MemoryStream();
        img.Save(ms, ImageFormat.Png);
     
        ms.Position = 0;
     
        return new FileStreamResult(ms, "image/png");
    }
