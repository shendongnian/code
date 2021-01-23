    int getXOffset(Control rb)
    {
        int offset = -1;
        string save = rb.Text;
        Color saveC = rb.ForeColor;
        Size saveSize = rb.Size;
        ContentAlignment saveCA = ContentAlignment.MiddleLeft;
        if  (rb is Label)
        {
            saveCA = ((Label)rb).TextAlign;
            ((Label)rb).TextAlign = ContentAlignment.BottomLeft;
        }
        using (Bitmap bmp = new Bitmap(rb.ClientSize.Width, rb.ClientSize.Height))
        using (Graphics G = rb.CreateGraphics() )
        {
            rb.Text = "_";
            rb.ForeColor = Color.Red;
            rb.DrawToBitmap(bmp, rb.ClientRectangle);
            int x = 0; // s.Width;
            while (offset < 0 && x < bmp.Width - 1)
            {
                for (int y = bmp.Height-1; y > bmp.Height / 2; y--)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (c.R > 0 && c.G == 0)     { offset = x; break; }
                }
                x++;
            }
        }
        rb.Text = save;
        rb.ForeColor = saveC;
        rb.Size = saveSize;
        if (rb is Label)
        {
            ((Label)rb).TextAlign =  saveCA;
        }
        return offset;
    }
