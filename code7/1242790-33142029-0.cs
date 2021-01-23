    var b = new Bitmap(width, height);
    using (Graphics g = Graphics.FromImage(b))
    {
        var lastPoint = points[0];
        for (int i = 1; i < points.Length; i++)
        {
            var p = points[i];
            // When the user takes the pen off the device, X/Y is set to -1
            if ((lastPoint.X >= 0 || lastPoint.Y >= 0) && (p.X >= 0 || p.Y >= 0))
                g.DrawLine(Pens.Black, lastPoint.X, lastPoint.Y, p.X, p.Y);
            lastPoint = p;
        }
        // g.Flush(); not necessary
        pictureBox1.Image = b;
        b.Save("C:\\temp\\test.bmp");
    }
