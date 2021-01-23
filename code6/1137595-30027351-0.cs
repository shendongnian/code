    private Timer _timer = new Timer {Interval = 500};
    public Form1()
    {
        InitializeComponent();
        _timer.Tick += TimerOnTick;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        if (panel1.Controls.Count > 0)
        {
            var wasVisible = panel1.VerticalScroll.Visible;
            panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
            buttons.RemoveAt(buttons.Count - 1);
            if (wasVisible != panel1.VerticalScroll.Visible)
            {
                _timer.Start();
            }
        }
    }
    private bool IsBackgroundColor()
    {
        var point = panel1.Location;
        point.Offset(panel1.Width - 9, panel1.Height - 11);
        point = PointToScreen(point);
        Image imgScreen = new Bitmap(1, 1);
        using (Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        using (Graphics gr = Graphics.FromImage(imgScreen))
        {
            g.CopyFromScreen(point, new Point(0, 0), new Size(1, 1));
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gr.DrawImage(bmp, new Rectangle(0, 0, 1, 1));
            var color = bmp.GetPixel(0, 0);
            return color.R == panel1.BackColor.R && color.G == panel1.BackColor.G && color.B == panel1.BackColor.B;
        }
    }
    private void TimerOnTick(object sender, EventArgs eventArgs)
    {
        if (!IsBackgroundColor() && !panel1.VerticalScroll.Visible)
        {
            panel1.Refresh();
        }
        else
        {
            _timer.Stop();
        }
    }
