        bool moving = false; Point click = new Point(0, 0); 
    System.Timers.Timer _MOVER = new System.Timers.Timer();
    public PersonControl() 
    {
        InitializeComponent();
        _MOVER.Elapsed += new System.Timers.ElapsedEventHandler((o, v) => { Dispatcher.Invoke(Move); });
        _MOVER.Enabled = true;
        _MOVER.Interval = 10;
    }
    private void _MouseDown(object sender, MouseButtonEventArgs e)
    {
        moving = true;
        click = Mouse.GetPosition(this);
        Canvas.SetZIndex(this, 100);
        _MOVER.Start();
    }
    private void _MouseUp(object sender, MouseButtonEventArgs e) 
    { 
        moving = false;
        Canvas.SetZIndex(this, 0);
        _MOVER.Stop();
    }
    private void Move()
    {
        if (moving == true)
        {
            Point po = Mouse.GetPosition(this);
            this.Margin = new Thickness(this.Margin.Left + (po.X - click.X), this.Margin.Top + (po.Y - click.Y), 0, 0);
        }
    }
