    var newImage = new Bitmap(oldImage.Width, oldImage.Height);
    using (var g = Graphics.FromImage(newImage))
    {
        g.Clear(Color.White);
        g.DrawImage(oldImage, new Point(0, 0));        
    }
