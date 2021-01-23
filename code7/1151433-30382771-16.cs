    int getXOffset(Control ctl)
    {
        int offset = -1;
        string save = ctl.Text; Color saveC = ctl.ForeColor; Size saveSize = ctl.Size;
        ContentAlignment saveCA = ContentAlignment.MiddleLeft;
        if  (ctl is Label)
        {
            saveCA = ((Label)ctl).TextAlign;
            ((Label)ctl).TextAlign = ContentAlignment.BottomLeft;
        }
        using (Bitmap bmp = new Bitmap(ctl.ClientSize.Width, ctl.ClientSize.Height))
        using (Graphics G = ctl.CreateGraphics() )
        {
            ctl.Text = "_";
            ctl.ForeColor = Color.Red;
            ctl.DrawToBitmap(bmp, ctl.ClientRectangle);
            int x = 0; 
            while (offset < 0 && x < bmp.Width - 1)
            {
                for (int y = bmp.Height-1; y > bmp.Height / 2; y--)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (c.R > 128 && c.G == 0)     { offset = x; break; }
                }
                x++;
            }
        }
        ctl.Text = save;  ctl.ForeColor = saveC;   ctl.Size = saveSize;
        if (ctl is Label)  { ((Label)ctl).TextAlign =  saveCA;   }
        return offset;
    }
