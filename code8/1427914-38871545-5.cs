    public MainWindow()
    {
        InitializeComponent();
        Min.Text = _currentMinimum.ToString();
        Max.Text = _currentMaximum.ToString();
    }
    private double _currentMinimum = 10;
    private double _currentMaximum= 100;
    private void UpDownBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if ((double) e.NewValue < _currentMinimum)
            Spinner.Value = (double)e.NewValue + (_currentMaximum - _currentMinimum);
        else if ((double) e.NewValue > _currentMaximum)
            Spinner.Value = (double)e.NewValue - (_currentMaximum - _currentMinimum);
    }
    private void Min_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double minimum;
        if (double.TryParse(Min.Text, out minimum))
            _currentMinimum = minimum;
    }
    private void Max_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double maximum;
        if (double.TryParse(Max.Text, out maximum))
            _currentMaximum= maximum;
    }
