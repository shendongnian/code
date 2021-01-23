    private void setCircleAlpha(int alpha, ref Bitmap b, ColumnVector2 pos, int diameter)
        {
            Graphics g = Graphics.FromImage(b);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            SolidBrush sb = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            g.FillEllipse(sb, pos.X, pos.Y, diameter, diameter);
        }
