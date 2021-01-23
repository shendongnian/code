    Timer tm = new Timer();
    public Form2(string url)
    {
        InitializeComponent();
        axWindowsMediaPlayer1.URL = url;
        tm.Interval = 1000;
        tm.Tick += tm_Tick;
        tm.Start();
    }
    int i = -1;
    void tm_Tick(object sender, EventArgs e)
    {
        if (++i < 100)
        {
            Bitmap screenshot = new Bitmap(axWindowsMediaPlayer1.Bounds.Width, axWindowsMediaPlayer1.Bounds.Height);
            Graphics g = Graphics.FromImage(screenshot);
            g.CopyFromScreen(axWindowsMediaPlayer1.PointToScreen(
                        new System.Drawing.Point()).X,
                    axWindowsMediaPlayer1.PointToScreen(
                        new System.Drawing.Point()).Y, 0, 0, axWindowsMediaPlayer1.Bounds.Size);
            pictureBox1.BackgroundImage = screenshot;
        }
        else
        {
            i = -1;
            tm.Stop();
        }
    }
