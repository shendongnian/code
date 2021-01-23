    public Form1()
    {
        InitializeComponent();
        Bitmap level = (Bitmap)Image.FromFile("D:\\LEDmeter0.png");
        bmpL0 = level.Clone(new Rectangle(Point.Empty, level.Size), 
                            PixelFormat.Format32bppPArgb);
        level = (Bitmap)Image.FromFile("D:\\LEDmeter1.png");
        bmpL1 = level.Clone(new Rectangle(Point.Empty, level.Size), 
                            PixelFormat.Format32bppPArgb);
    }
    Bitmap bmpL0 = null;
    Bitmap bmpL1 = null;
    Random R = new Random(0);
    private void timer1_Tick(object sender, EventArgs e)
    {
        Size sz = pictureBox2.ClientSize;
        int level = R.Next(10) + R.Next(5) + R.Next(3) ;  // 0-17
        level = 27 * level + 50;
        using (Graphics G = pictureBox2.CreateGraphics())
        {
            G.DrawImage(bmpL1, new Rectangle(0, 0, sz.Width, sz.Height),
                new Rectangle(0, 0, sz.Width, sz.Height), GraphicsUnit.Pixel);
            G.DrawImage(bmpL0, new Rectangle(0, 0, sz.Width, level),
                new Rectangle(0, 0, sz.Width, level), GraphicsUnit.Pixel);
        }
    }
