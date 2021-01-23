    double x = 0;
    Timer timer1 = new Timer();
    bool stop = false;
    public Form1()
    {
         InitializeComponent();
         timer1.Interval = 100;
         timer1.Tick += new EventHandler(timer1_Tick);
    }
    
    private void Start_Stop_Click(object sender, EventArgs e)
    {
         if (!stop)
         {
             timer1.Start();
             stop = true;
         }
         else
         {
             timer1.Stop();
             stop = false;
         }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
         x = x + 0.00522222222222222222222222222222;
         textBox1.Text = x.ToString();
    }
