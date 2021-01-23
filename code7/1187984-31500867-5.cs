    double x = 0;
    Timer timer1 = new Timer();
    public Form1()
    {
         InitializeComponent();
         timer1.Interval = 100;
         timer1.Tick += new EventHandler(timer1_Tick);
    }
    
    private void Start_Stop_Click(object sender, EventArgs e)
    {
         if (timer1.Enabled)
         {
             timer1.Stop();
         }
         else
         {
             timer1.Start();
         }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
         x = x + 0.00522222222222222222222222222222;
         textBox1.Text = x.ToString();
    }
