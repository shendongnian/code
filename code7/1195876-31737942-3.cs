    private Timer timer; //Declare the timer at class level
    public Form1()
    {
        InitializeComponent();
        // We set it to expire after one second, and link it to the method below
        timer = new Timer {Interval = 1000}; //Interval is the amount of time in millis before it fires
        timer.Tick += OnTick;
    }
    private void OnTick(object sender, EventArgs eventArgs)
    {
        timer.Stop(); //Don't forget to stop the timer, or it'll continue to tick
        Point coordinates = Cursor.Position;
        MessageBox.Show("Coordinates are: " + coordinates);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Pick a position after clicking OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
        {
            timer.Start();
        }
    }
