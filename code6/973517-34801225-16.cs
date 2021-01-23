    var dbm = new DirectBitmap(200, 200);
    using (var g = Graphics.FromImage(dbm.Bitmap))
    {
        g.DrawRectangle(Pens.Black, new Rectangle(50, 50, 100, 100));
    }
