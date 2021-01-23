    void drawLines()
    {
        if (canvas.BackgroundImage != null) canvas.BackgroundImage.Dispose();
        Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
        using (Graphics G = Graphics.FromImage(bmp))
            foreach (Tuple<Label, Label> t in lines)
            {
                Point p1 = new Point(t.Item1.Left + t.Item1.Width / 2,
                                     t.Item1.Top + t.Item1.Height / 2);
                Point p2 = new Point(t.Item2.Left + t.Item2.Width / 2, 
                                     t.Item2.Top + t.Item2.Height / 2);
                G.DrawLine(Pens.Black, p1, p2);
            }
        canvas.BackgroundImage = bmp;
    }
