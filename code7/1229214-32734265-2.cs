    public ObservableCollection<object> Values
    {
        get { return (ObservableCollection<object>)GetValue(ValuesProperty); }
        set { SetValue(ValuesProperty, value); }
    }
    public static readonly DependencyProperty ValuesProperty =
        DependencyProperty.Register(
            "Values", typeof(ObservableCollection<object>),
            typeof(MyUserControl),
            new PropertyMetadata(
                null));
