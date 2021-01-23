    void drawIntoImage()
    {
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        {
            // we want the tranparency to copy over the black pixels
            G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            G.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            using (Pen somePen = new Pen(Color.Transparent, penWidth))
            {
                somePen.MiterLimit = penWidth / 2;
                somePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                somePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                somePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                if (currentLine.Count > 1)
                    G.DrawCurve(somePen, currentLine.ToArray());
            }
        }
        // enforce the display:
        pictureBox1.Image = pictureBox1.Image;
    }
