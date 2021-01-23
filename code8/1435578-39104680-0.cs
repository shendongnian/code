    using (Bitmap b = new Bitmap(width, height))
    {
        using (Graphics g = Graphics.FromImage(b))
        {
            Point p1 = myControl.PointToScreen(new Point(0, 0));
            g.CopyFromScreen(p1.X, p1.Y, 0, 0, size);
        }
        // do stuff here with your Bitmap
    }
