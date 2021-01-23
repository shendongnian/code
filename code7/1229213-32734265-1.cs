    public ObservableCollection<IAwesome> Values
    {
        get { return (ObservableCollection<IAwesome>)GetValue(ValuesProperty); }
        set { SetValue(ValuesProperty, value); }
    }
    public static readonly DependencyProperty ValuesProperty =
        DependencyProperty.Register(
            "Values", typeof(ObservableCollection<IAwesome>),
            typeof(MyUserControl),
            new PropertyMetadata(
                null));
