    using (Pen myPen = new Pen(Color.Blue, 24f))
    {
        // either another LineJoine;
        myPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
        // or a reduced MiterLimit:
        myPen.MiterLimit = 1+ myPen.Width / 5f;
    }
    
