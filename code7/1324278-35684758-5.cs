    public Form1()
    {
        InitializeComponent();
        Timer timer = new Timer();//Create new instance of Timer.
        timer.Interval = 1;
        timer.Tick += new EventHandler(timer_Tick);//Set an eventhandler to occur after each 1000th of a second.
        timer.Enabled = true;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        if (ControlPressed && E_Pressed)
        {
            btnCompleteSalesAndPrint_Click(sender, new EventArgs());
        }
    }
