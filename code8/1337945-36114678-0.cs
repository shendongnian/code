    public static readonly DependencyProperty MyTimeProperty =
        DependencyProperty.Register("MyTime", typeof(Time), typeof(MyControl));
    public Time MyTime
    {
        get { return (Time)GetValue(MyTimeProperty); }
        set { SetValue(MyTimeProperty, value); }
    }
