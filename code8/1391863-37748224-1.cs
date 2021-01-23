    public object MyProperty
    {
        get { return (object)GetValue(MyPropertyProperty); }
        set { SetValue(MyPropertyProperty, value); }
    }
    public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("MyProperty", typeof(object), typeof(MyUserControl), new PropertyMetadata(false));
