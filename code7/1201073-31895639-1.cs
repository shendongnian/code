    private Timer _timer;
    
    public Form() // Initialize timer in your form constructor
    {
        InitializeComponent();
        _timer = new Timer();
        _timer.Interval = 10000; // miliseconds
        _timer.Tick += _timer_Tick; // Subscribe timer to it's tick event
    }
    private void _timer_Tick(object sender, EventArgs e)
    {
        SendData();
    }
    private void cmd_send_Click_1(object sender, EventArgs e)
    {
        if (!_timer.Enabled) // If timer is not running send data and start refresh interval
        {
            SendData();
            _timer.Enabled = true;
        }
        else // Stop timer to prevent further refreshing
        {
            _timer.Enabled = false;
        }
    }
    private void SendData()
    {
        // Your code here
    }
