    Rectangle[] rects = blobcounter.GetObjectsRectangles();
    foreach(Rectangle recs in rects)
        if (rects.Length > 0)
        {
            foreach (Rectangle objectRect in rects)
            {
                Graphics graphic = Graphics.FromImage(video2);
                using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
                {
                    graphic.DrawRectangle(pen, objectRect);
                }
                graphic.Dispose();
            }
        }
