    public MainWindow()
    {
         InitializeComponent();
         DispatcherTimer timer = new DispatcherTimer();
         timer.Interval = new TimeSpan(0, 0, 20);
         timer.Start();
         timer.Tick += timer_Tick;
    }
    void timer_Tick(object sender, EventArgs e)
    {
         DataGenerator dg = new DataGenerator();
         a.Text = dg.RandomHRValue().ToString();
    }
