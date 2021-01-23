    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            "Value", typeof(decimal), typeof(NumericUpDown),
            new PropertyMetadata(
                (d, e) =>
                {
                    ((NumericUpDown)d).OnValueChanged();
                }));
    public decimal Value
    {
        get { return (decimal)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value);}
    }
