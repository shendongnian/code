    using System.Windows.Forms;
    
    public Alertbox()
    {
        InitializeComponent();
        var timer = new Timer {Interval = 2*60*1000};
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    void Timer_Tick(object sender, EventArgs e)
    {
        BT_AddTrigger.Text += "test";
    }
