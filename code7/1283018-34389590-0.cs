    public void DigitalGraphicsDisplay(int red, int green, int blue)
    {
        if (Display.Image == null)
        {
            Bitmap bmp = new Bitmap(Display.Width, Display.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            Display.Image = bmp;
        }
    
        using (Graphics g = Graphics.FromImage(Display.Image))
        {
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(red, green, blue)))
            {
                g.FillRectangle(sb, x, y, 1, 1);
            }
        }
        Display.Invalidate();
                
        if (x < screen.Width)
        {
            x = x + 1;
        }
        else if (x == screen.Width)
        {
            x = 0;
            if (y < screen.Height)
            {
                y = y + 1;
            }
            else if (y == screen.Height)
            {
                y = 0;
            }
        }
    }
