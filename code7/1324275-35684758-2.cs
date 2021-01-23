    public Form1()
    {
        InitializeComponent();
        Timer timer = new Timer();
        timer.Interval = 1;
        timer.Tick += new EventHandler(timer_Tick);
        timer.Enabled = true;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        if (ControlPressed && E_Pressed)
        {
            btnCompleteSalesAndPrint_Click(sender, new EventArgs());
        }
    }
