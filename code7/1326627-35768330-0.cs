    List<Car> _myCars = new List<Car>();
    private Form1()
    {
        _timer = new Timer();
        _timer.Interval = 50;
        _timer.Tick += Timer_Tick;
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        foreach(var car in _myCars.ToArray())
        {
            car.Location = new Point(car.Location.X, car.Location.Y - 3);
            if(car.Location.Y < 0)
                _myCars.Remove(car);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        _myCars.Add(new Car());
    }
