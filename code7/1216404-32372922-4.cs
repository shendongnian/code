    void drawIntoImage()
    {
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        {
            // we want the tranparency to copy over the blasck pixels
            G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            G.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            using (Pen somePen = new Pen(Color.Transparent, yourPenwidth))
                if (currentLine.Count > 1) 
                    G.DrawCurve(somePen, currentLine.ToArray());
        }
        // enforce the display:
        pictureBox1.Image = pictureBox1.Image;
    }
