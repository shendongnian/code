    public static readonly DependencyProperty SystemNameProperty =
        DependencyProperty.Register("SystemName", typeof(string), typeof(SubSystem));
    public string SystemName
    {
        get { return (string)GetValue(SystemNameProperty); }
        set { SetValue(SystemNameProperty, value); }
    }
