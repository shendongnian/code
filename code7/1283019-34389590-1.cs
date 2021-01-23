    int x = 0;
    int y = 0;
    public void DigitalGraphicsDisplay(int red, int green, int blue)
    {
        if (Display.Image == null)
        {
            Bitmap NewBMP = new Bitmap(Display.ClientRectangle.Width, Display.ClientRectangle.Height);
            using (Graphics g = Graphics.FromImage(NewBMP))
            {
                g.Clear(Color.White);
            }
            Display.Image = NewBMP;
        }
    
        (Display.Image as Bitmap).SetPixel(x, y, Color.FromArgb(red, green, blue));
    
        Display.Invalidate();
    
        x++;
    
        if (x >= Display.Image.Width)
        {
            x = 0;
            y++;
    
            if (y >= Display.Image.Height)
            {
                y = 0;
            }
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // Temporary code to show that it works (Due to Bitmap.SetPixel() it will be slow)
        for (int I = 1; I < Display.ClientRectangle.Width * Display.ClientRectangle.Height; I++)
            DigitalGraphicsDisplay((I/255)%255, (I % Display.ClientRectangle.Width) % 255, 127);
    }
