    private int x = 0;
    public Form1 ()
    {
        InitializeComponent();
    }
    private void button1_Click ( object sender, EventArgs e )
    {
        InitTimer();
    }
    private void timer1_Tick ( object sender, EventArgs e )
    {
        bool s = IsFinished();
        if (s == true)
            textBox1.Text = "true";
    }
    private void InitTimer ()
    {
        timer1 = new Timer();
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Interval = 3000; //30000 is 30 seconds
        timer1.Start();
    }
    private bool IsFinished ()
    {
        if (++x == 2) //1 min
        {
            timer1.Stop();
            return true;
        }
        else return false;
    }
