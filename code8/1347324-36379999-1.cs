    private void button1_Click(object sender, EventArgs e)
    {
        CreateTextIcon("89");
    }
    public void CreateTextIcon(string str)
    {
        Font fontToUse = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        Brush brushToUse = new SolidBrush(Color.White);
        Bitmap bitmapText = new Bitmap(16, 16);
        Graphics g = System.Drawing.Graphics.FromImage(bitmapText);
        IntPtr hIcon;
        
        g.Clear(Color.Transparent);
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
        g.DrawString(str, fontToUse, brushToUse, -4, -2);
        hIcon = (bitmapText.GetHicon());
        notifyIcon1.Icon = System.Drawing.Icon.FromHandle(hIcon);
        //DestroyIcon(hIcon.ToInt32);
    }
