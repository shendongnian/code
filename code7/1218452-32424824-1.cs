    Rectangle[] rects = blobcounter.GetObjectsRectangles();
    foreach (Rectangle recs in rects)
    {
        if (rects.Length > 0)
        {
            Graphics graphic = Graphics.FromImage(video2);
            foreach (Rectangle objectRect in rects)
            {
                graphic.DrawRectangle(Pens.LightGreen, objectRect);
            }
            graphic.DrawRectangle(Pens.Red, Center.X - 4, Center.Y - 4, 8, 8);
            graphic.Dispose();
        }
    }
