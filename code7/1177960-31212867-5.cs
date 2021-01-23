    public Form1()
    {
        InitializeComponent();
        dragFrame.Visible = false;
        dragFrame.BorderStyle = BorderStyle.FixedSingle;
        Controls.Add(dragFrame);
        timer1.Interval = 20;
    }
